import pyodbc
from telethon.sync import TelegramClient, events
from datetime import datetime

api_id = 22332340
api_hash = "e054c9c8b94d7737b5121aaf72399ed7"

server = 'OBLAKOV0372'
database = 'CryptoHelper'
connection_string = f"Driver=ODBC Driver 17 for SQL Server;Server={server};Database={database};Trusted_Connection=yes;"

connection = pyodbc.connect(connection_string)
cursor = connection.cursor()

def insert_message(telegram_group_id, telegram_group_username, sender_id, sender_username, message, date, link_for_message, message_type):
    query = "INSERT INTO TelegramMessages (telegram_group_id, telegram_group_username, sender_id, sender_username, message, date, link_for_message, Type) VALUES (?, ?, ?, ?, CAST(? AS NVARCHAR(MAX)), ?, ?, ?)"
    values = (telegram_group_id, telegram_group_username, sender_id, sender_username, message, date, link_for_message, message_type)
    try:
        cursor.execute(query, values)
        connection.commit()
    except Exception as e:
        print("Error while inserting into database:", e)
        connection.rollback()

with TelegramClient("session", api_id, api_hash) as client:
    group_ids = ["doubletop_otc","tvrn_otc","MarketICOBOG","mediasocialmarket"]

    @client.on(events.NewMessage(chats=group_ids))
    async def handler(event):
        if event.from_id.user_id != 553147242:
            user = await event.get_sender()
            telegram_group_id = event.peer_id.channel_id
            telegram_group_username = (await event.get_chat()).username
            sender_id = event.from_id.user_id
            sender_username = user.username
            message = event.message.text
            date = event.date
            link_for_message = f"https://t.me/{telegram_group_id}/{event.id}"
            
            # Проверяем, содержит ли сообщение ключевые слова "wts" или "wtb"
            if "wts" in message.lower():
                message_type = "wts"
            elif "wtb" in message.lower():
                message_type = "wtb"
            else:
                message_type = None

            insert_message(telegram_group_id, telegram_group_username, sender_id, sender_username, message, date, link_for_message, message_type)
    
    print("Listening for new messages...")
    client.run_until_disconnected()

cursor.close()
connection.close()

