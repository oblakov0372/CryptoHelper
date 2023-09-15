export const changeDecimal = (number: number) => {
  return number === 0
    ? number.toFixed(0)
    : number > 1
    ? number.toFixed(2)
    : number.toFixed(5);
};

export const formatDate = (dateString: string) => {
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
