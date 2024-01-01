import dayjs from "dayjs";

export const formatNumberWithComma = (number: number | undefined) => {
  return number ? number.toLocaleString() : 0;
}

export const formatToFullDate = (date: string | Date) => {
  if (!date)
    return 'Lỗi thời gian!!!'
  return dayjs(date).format('HH:mm DD/MM/YYYY')
}

export function uuidv4() {
  return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
    (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
  );
}