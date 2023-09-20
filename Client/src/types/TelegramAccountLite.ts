export enum Status {
  Scamer = "Scamer",
  Reseller = "Reseller",
}

export interface TelegramAccountLite {
  id: number;
  telegramUsername: string | null;
  status: Status | null;
}
