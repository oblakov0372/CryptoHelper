import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { anonymRequest } from "../../utils/Request";
import { TelegramAccountBaseType } from "../../types/TelegramAccountBaseType";
import { formatDate } from "../../utils/Utils";

const TelegramAccount = () => {
  const { telegramAccountId } = useParams();
  const [telegramAccountData, setTelegramAccountData] =
    useState<TelegramAccountBaseType>();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const response = await anonymRequest(
          `TelegramUsers/${telegramAccountId}`
        );
        setTelegramAccountData(response.data);
      } catch (error) {}
    };
    fetchData();
  });
  return (
    <div>
      <h2>User Page</h2>
      <h1>-</h1>
      <p>User ID: {telegramAccountData?.id}</p>
      <h1>-</h1>
      <p>countAllMessages: {telegramAccountData?.countAllMessages}</p>
      <h1>-</h1>
      <p>countMessagesWtb: {telegramAccountData?.countMessagesWtb}</p>
      <h1>-</h1>
      <p>countMessagesWts: {telegramAccountData?.countMessagesWts}</p>
      <h1>-</h1>
      <p>linkToFirstMessage: {telegramAccountData?.linkToFirstMessage}</p>
      <h1>-</h1>
      <p>status: {telegramAccountData?.status}</p>
      <h1>-</h1>
      <p>userName: {telegramAccountData?.userName}</p>
      <h1>-</h1>
      <p>linkToUserTelegram: {telegramAccountData?.linkToUserTelegram}</p>
      <h1>-</h1>
      <p>
        firstActivity:
        {telegramAccountData && formatDate(telegramAccountData?.firstActivity)}
      </p>
      <h1>-</h1>
      <p>
        lastActivity:
        {telegramAccountData && formatDate(telegramAccountData?.lastActivity)}
      </p>
    </div>
  );
};

export default TelegramAccount;
