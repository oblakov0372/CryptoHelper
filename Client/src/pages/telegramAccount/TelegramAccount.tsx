import { useParams } from "react-router-dom";

const TelegramAccount = () => {
  const { telegramAccountId } = useParams();
  return (
    <div>
      <h2>User Page</h2>
      <p>User ID: {telegramAccountId}</p>
    </div>
  );
};

export default TelegramAccount;
