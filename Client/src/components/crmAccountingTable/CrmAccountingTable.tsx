import React from "react";
import { TelegramAccountLite } from "../../types/TelegramAccountLite";

type CrmTelegramAccountingTableProperty = {
  telegramAccounting: TelegramAccountLite[];
};

const CrmAccountingTable: React.FC<CrmTelegramAccountingTableProperty> = ({
  telegramAccounting,
}) => {
  return (
    <table className="text-center w-full bg-black text-white">
      <thead className="border-b-2">
        <tr>
          <th className="px-3 py-2">ID</th>
          <th className="px-3 py-2">Username</th>
          <th className="px-3 py-2">Status</th>
        </tr>
      </thead>
      <tbody>
        {telegramAccounting.map((telegramAccount: TelegramAccountLite) => (
          <tr key={telegramAccount.id} className="border-b border-gray-400">
            <td className="font-extrabold px-3 py-2">{telegramAccount.id}</td>
            <td className="font-semibold px-3 py-2">
              {telegramAccount.telegramUsername !== null
                ? telegramAccount.telegramUsername
                : "None"}
            </td>
            <td className="font-extrabold px-3 py-2">
              {telegramAccount.status !== null
                ? telegramAccount.status
                : "None"}
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
};

export default CrmAccountingTable;
