from telethon import events
from datetime import datetime

async def handler(event, should_save_message, insert_message, insert_or_get_telegram_user):
    if event.from_id.user_id != 553147242:
        user = await event.get_sender()
        telegram_group_id = event.peer_id.channel_id
        telegram_group_username = (await event.get_chat()).username
        sender_id = event.from_id.user_id
        sender_username = user.username
        message = event.message.text
        date = datetime.now()
        link_for_message = f"https://t.me/{telegram_group_id}/{event.id}"

        # Проверяем, содержит ли сообщение ключевые слова "wts" или "wtb"
        if "wts" in message.lower():
            message_type = "wts"
        elif "wtb" in message.lower():
            message_type = "wtb"
        else:
            message_type = None

        if should_save_message(message) and sender_username not in ("tvrn_help_bot", "shieldy_bot"):
            # Получаем Id пользователя или добавляем его, если его нет в базе данных
            sender_id = insert_or_get_telegram_user(sender_id, sender_username)

            # Добавляем сообщение в базу данных
            insert_message(telegram_group_id, telegram_group_username, sender_id, sender_username, message, date, link_for_message, message_type)


def setup_telegram_events(client, group_ids, should_save_message, insert_message,insert_or_get_telegram_user):
    @client.on(events.NewMessage(chats=group_ids))
    async def event_handler(event):
        await handler(event, should_save_message, insert_message,insert_or_get_telegram_user)
