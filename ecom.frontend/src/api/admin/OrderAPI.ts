import { http } from "..";

export function fetchWaitingOrders(){
  return http.get(`/order/pending`);
};

export function fetchCompletedOrders(){
  return http.get(`/order/completed`);
};

export function fetchCanceledOrders(){
  return http.get(`/order/canceled`);
};

export function fetchDeliveryOrders(){
  return http.get(`/order/delivering`);
};

export function finishOrder(id: number){
  return http.patch(`/order/complete/${id}`);
};
export function deliveryOrder(id: number){
  return http.patch(`/order/deliver/${id}`);
};
export function cancelOrder(id: number){
  return http.patch(`/order/cancel/${id}`);
};

export function fetchAllOrders(){
  return http.get(`/order`);
}
