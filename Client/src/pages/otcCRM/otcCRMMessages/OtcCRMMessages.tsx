import { useEffect, useState } from "react";
import { anonymRequest } from "../../../utils/Request";
import CrmMessagesTable from "../../../components/crmMessagesTable/CrmMessagesTable";

const OtcCRMMessages = () => {
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
    <div>
      <CrmMessagesTable telegramMessages={telegramMessages} />
    </div>
  );
};

export default OtcCRMMessages;
