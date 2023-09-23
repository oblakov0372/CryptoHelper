import pyodbc
from telethon.sync import TelegramClient, events
from datetime import datetime
import re
api_id = 22332340
api_hash = "e054c9c8b94d7737b5121aaf72399ed7"

connection_string = (
    "Driver={ODBC Driver 17 for SQL Server};"
    "Server=tcp:oblakovsqlserver.database.windows.net,1433;"
    "Database=CryptoHelper;"
    "Uid=oblakovadmin;"
    "Pwd=DemaOblak1#;"
    "Encrypt=yes;"
    "TrustServerCertificate=no;"
    "MultipleActiveResultSets=no;"
    "Connection Timeout=30;"
)

connection = pyodbc.connect(connection_string)
cursor = connection.cursor()

def should_save_message(message_text):
    if re.search(r'\?{5,}', message_text):
        return False  
    return True  

def user_exists(user_id):
    query = "SELECT COUNT(*) FROM TelegramUsers WHERE Id = ?"
    cursor.execute(query, (user_id,))
    count = cursor.fetchone()[0]
    return count > 0

def insert_user(user_id, username):
    if not user_exists(user_id):
        query = "INSERT INTO TelegramUsers (Id, TelegramUsername) VALUES (?, ?)"
        values = (user_id, username)
        try:
            cursor.execute(query, values)
            connection.commit()
        except Exception as e: 
            print("Error while inserting into TelegramUsers table:", e)
            connection.rollback()


def insert_message(telegram_group_id, telegram_group_username, sender_id, sender_username, message, date, link_for_message, message_type):
    insert_user(sender_id, sender_username)
    
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
        user = await event.get_sender()
        telegram_group_id = event.peer_id.channel_id
        telegram_group_username = (await event.get_chat()).username
        sender_id = event.from_id.user_id
        sender_username = user.username
        message = event.message.text
        date = datetime.now()
        link_for_message = f"https://t.me/{telegram_group_username}/{event.id}"
        
        # Проверяем, содержит ли сообщение ключевые слова "wts" или "wtb"
        if "wts" in message.lower():
            message_type = "wts"
        elif "wtb" in message.lower():
            message_type = "wtb"
        else:
            message_type = None

        if should_save_message(message) and sender_username not in ("tvrn_help_bot", "shieldy_bot"):
            insert_message(telegram_group_id, telegram_group_username, sender_id, sender_username, message, date, link_for_message, message_type)
    
    print("Listening for new messages...")
    client.run_until_disconnected()

cursor.close()
connection.close()