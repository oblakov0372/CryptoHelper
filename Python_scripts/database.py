import pyodbc

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

def insert_or_get_telegram_user(telegram_id, telegram_username):
    # Проверяем наличие пользователя в базе данных
    query = "SELECT Id FROM TelegramUsers WHERE TelegramId = ?"
    cursor.execute(query, (telegram_id,))
    result = cursor.fetchone()

    # Если пользователь не найден, добавляем его в базу данных
    if not result:
        query = "INSERT INTO TelegramUsers (TelegramId, TelegramUsername) VALUES (?, ?)"
        cursor.execute(query, (telegram_id, telegram_username))
        connection.commit()

        # Получаем Id только что добавленного пользователя
        cursor.execute(query, (telegram_id,))
        result = cursor.fetchone()

    # Возвращаем Id пользователя
    return result[0]


def close_database_connection():
    cursor.close()
    connection.close()
