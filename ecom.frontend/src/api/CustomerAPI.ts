import { http } from ".";
import ICart from "../interface/Cart";

export function fetchAllProducts(){
  return http.get(`/Product`);
};

export function fetchProductDetail(where: any){
  return http.get(`/Product`, {params: where})
}

export function increaseViewForProduct(id: number) {
  return http.patch(`/Product/viewed/${id}`);
}

export function fetchProductBySlug(slug: string){
  return http.get(`/Product/slug/${slug}`)
}

export function createOrder(order: any){
  return http.post('/Order', order)
}

export function getVoucher(voucherCode: string, isActive: boolean = true){ 
  return http.get(`/voucher/${voucherCode}?isActive=${isActive}`)
}

export function createReceipt(newReceipt: any){
  return http.post(`/Receipt`, newReceipt);
}

export function updateUser(newUser: any, phoneNumber: string){
  return http.patch(`/user/${phoneNumber}`, newUser)
}

export function userLoggedIn(phoneNumber: string){
  return http.patch(`/User/logged-in/${phoneNumber}`)
}

export function getOrdersByPhoneNumber(phoneNumber: string){
  return http.get(`/Order?phoneNumber=${phoneNumber}`)
}

export function getOrder(id: string){
  return http.get(`/Order/${id}`);
}

export function getCart(userID: string){
  return http.get(`/Cart/?userID=${userID}`);
}

export function updateCart(cartID: number, updateFields: any){
  return http.patch(`/Cart/${cartID}`, updateFields);
}

export function createCart(newCart: any){
  return http.post(`/Cart`, newCart);
}

export function deleteCart(cartID: number){
  // console.log(cartID)
  return http.delete(`/Cart/${cartID}`);
}