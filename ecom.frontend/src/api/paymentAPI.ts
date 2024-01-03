import { http } from './index';
export function getVietQR(message: string, amount: number) {
  return http.get(`/payment/viet-qr?message=${message}&&amount=${amount}`);
}

export function createVnPayPaymentUrl(orderId: number, receiptId: number, amount: number) {
  return http.post(`/Receipt/payment/${receiptId}?orderId=${orderId}`, { amount });
}

export function validateReiceptResult(receiptId: string, validateData: any) {
  return http.post(`/Receipt/payment/${receiptId}/confirm`, validateData);
}