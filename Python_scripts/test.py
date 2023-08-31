from telethon.sync import TelegramClient, events
from telethon.sessions import StringSession

api_id = 22332340
api_hash = "e054c9c8b94d7737b5121aaf72399ed7"

with TelegramClient("session", api_id, api_hash) as client:
    group_ids = ["doubletop_otc"]

    @client.on(events.NewMessage(chats=group_ids))
    async def handler(event):
        if "wts" in event.message.text.lower() or "wtb" in event.message.text.lower():
            user = await event.get_sender()
            group_id = event.peer_id.channel_id
            group_username = (await event.get_chat()).username
            sender_id = user.id
            sender_username = user.username
            message = event.message.text
            date = event.date
            link_for_message = f"https://t.me/{group_username}/{event.id}"
            
            print(f"Group ID: {group_id}\nGroup Username: {group_username}\n#############")
            print(f"Date: {date}\nLink for Message: {link_for_message}\n#############")
            print(f"User ID: {sender_id}\nUsername: {sender_username}\nMessage: {message}")
            print("#################################")

    print("Listening for new messages...")
    client.run_until_disconnected()
