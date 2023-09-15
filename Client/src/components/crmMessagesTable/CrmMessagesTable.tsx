import { useEffect, useState } from "react";
import { anonymRequest } from "../../utils/Request";

type TelegramMessageType = {
  id: number;
  telegramGroupId: number;
  telegramGroupUsername: string | null;
  senderId: number;
  senderUsername: string | null;
  message: string | null;
  date: string;
  linkForMessage: string | null;
  type: string;
};

const formatDate = (dateString: string) => {
  const date = new Date(dateString);

  const options: Intl.DateTimeFormatOptions = {
    year: "numeric",
    month: "2-digit",
    day: "2-digit",
    hour: "2-digit",
    minute: "2-digit",
    second: "2-digit",
  };

  return date.toLocaleDateString(undefined, options);
};

const CrmMessagesTable = () => {
  const [telegramMessages, setTelegramMessages] = useState<
    TelegramMessageType[]
  >([]);
  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await anonymRequest("CRMTelegramMessages");
        setTelegramMessages(response.data);
      } catch (error) {
        console.error("Ошибка при получении данных:", error);
      }
    };
    fetchData();
  }, []);

  return (
    <table className="text-center w-full bg-black text-white">
      <thead className="border-b-2">
        <tr>
          <th className="px-3 py-2" style={{ maxWidth: "50px" }}>
            Group Username
          </th>
          <th className="px-3 py-2" style={{ maxWidth: "50px" }}>
            Type
          </th>
          <th className="px-3 py-2" style={{ maxWidth: "50px" }}>
            Sender
          </th>
          <th className="px-3 py-2" style={{ maxWidth: "250px" }}>
            Сообщение
          </th>
          <th className="px-3 py-2">Дата</th>
        </tr>
      </thead>
      <tbody>
        {telegramMessages.map((telegramMessage: TelegramMessageType) => (
          <tr key={telegramMessage.id} className="border-b border-gray-400">
            <td
              className="font-extrabold px-3 py-2"
              style={{ maxWidth: "50px" }}
            >
              {telegramMessage.telegramGroupUsername}
            </td>
            <td
              className="font-extrabold px-3 py-2"
              style={{ maxWidth: "50px" }}
            >
              {telegramMessage.type.toUpperCase()}
            </td>
            <td
              className="px-3 py-2 cursor-pointer"
              style={{ maxWidth: "50px" }}
            >
              <span className="font-bold">
                @{telegramMessage.senderUsername}
              </span>
              <span className="block font-medium ">
                {telegramMessage.senderId}
              </span>
            </td>
            <td className="px-3 py-2" style={{ maxWidth: "250px" }}>
              {telegramMessage.message}
            </td>
            <td style={{ maxWidth: "50px" }} className="px-3 py-2">
              {formatDate(telegramMessage.date)}
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default CrmMessagesTable;
