type TelegramMessageType = {
  id: number;
  telegramGroupId: number;
  telegramGroupUsername: string | null;
  senderId: number;
  senderUsername: string | null;
  message: string | null;
  date: Date;
  linkForMessage: string | null;
};

const CrmMessagesTable = () => {
  const telegramMessages: TelegramMessageType[] = [
    {
      id: 1,
      telegramGroupId: 123,
      telegramGroupUsername: "group1",
      senderId: 456,
      senderUsername: "user1",
      message:
        "WTS kyc service or already made acc Bitmart Bybit Galxe Binance Huobi Okx Kucoin Cryptocom And other kyc by you link Escrow only ",
      date: new Date("2023-09-12"),
      linkForMessage: "https://example.com/message/1",
    },
    {
      id: 2,
      telegramGroupId: 456,
      telegramGroupUsername: "group2",
      senderId: 789,
      senderUsername: "user2",
      message:
        "WTS 0.1$ Discord invites 0.1$ Reveel (r3vl) invites 1$ - Discord accounts 1$ - Twitter accounts",
      date: new Date("2023-09-13"),
      linkForMessage: "https://example.com/message/2",
    },
  ];
  return (
    <table className="text-center w-full bg-black text-white">
      <thead className="border-b-2">
        <tr>
          <th className="px-3 py-2" colSpan={1}>
            Group Username
          </th>
          <th className="px-3 py-2">Sender</th>
          <th className="px-3 py-2" colSpan={2}>
            Сообщение
          </th>
          <th className="px-3 py-2">Дата</th>
        </tr>
      </thead>
      <tbody>
        {telegramMessages.map((telegramMessage: TelegramMessageType) => (
          <tr key={telegramMessage.id} className="border-b border-gray-400">
            <td className="font-extrabold px-3 py-2" colSpan={1}>
              {telegramMessage.telegramGroupUsername}
            </td>
            <td className="px-3 py-2 cursor-pointer">
              <span className="font-bold">
                @{telegramMessage.senderUsername}
              </span>
              <span className="block font-medium ">
                {telegramMessage.senderId}
              </span>
            </td>
            <td className="px-3 py-2" colSpan={2}>
              {telegramMessage.message}
            </td>
            <td className="px-3 py-2">
              {telegramMessage.date.toLocaleDateString()}
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default CrmMessagesTable;
