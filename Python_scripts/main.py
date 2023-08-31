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

def insert_message(telegram_group_id, telegram_group_username, sender_id, sender_username, message, date, link_for_message):
    query = "INSERT INTO TelegramMessages (telegram_group_id, telegram_group_username, sender_id, sender_username, message, date, link_for_message) VALUES (?, ?, ?, ?, CAST(? AS NVARCHAR(MAX)), ?, ?)"
    values = (telegram_group_id, telegram_group_username, sender_id, sender_username, message, date, link_for_message)
    try:
        cursor.execute(query, values)
        connection.commit()
    except Exception as e:
        print("Error while inserting into database:", e)
        # Rollback the transaction if something goes wrong
        connection.rollback()



with TelegramClient("session", api_id, api_hash) as client:
    group_ids = ["doubletop_otc","tvrn_otc","MarketICOBOG","mediasocialmarket"]

    @client.on(events.NewMessage(chats=group_ids))
    async def handler(event):
        if ("wts" in event.message.text.lower() or "wtb" in event.message.text.lower()) and event.from_id.user_id != 553147242:
            user = await event.get_sender()
            telegram_group_id = event.peer_id.channel_id
            telegram_group_username = (await event.get_chat()).username
            sender_id = event.from_id.user_id
            sender_username = user.username
            message = event.message.text
            date = event.date
            link_for_message = f"https://t.me/{telegram_group_id}/{event.id}"
            
            print(f"Group ID: {telegram_group_id}\nGroup Username: {telegram_group_username}")
            print(f"Date: {date}\nLink for Message: {link_for_message}")
            print(f"User ID: {sender_id}\nUsername: {sender_username}\nMessage: {message}")
            print("#################################")

            insert_message(telegram_group_id, telegram_group_username, sender_id, sender_username, message,date, link_for_message)
    
    print("Listening for new messages...")
    client.run_until_disconnected()

cursor.close()
connection.close()
