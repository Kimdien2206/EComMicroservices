import { http } from "..";
import IDiscount from "../../interface/Discount";

export function fetchAllDiscounts(){
  return http.get(`/discount`);
};

export function createDiscount(name: string, discount: number) {
  return http.post('/discount', { 
    name : name, 
    discountAmount: discount 
  })
}

export function deleteDiscount(id: number) {
  return http.delete(`/discount/${id}`);
}

export function updateDiscount({ id, discount, name }: IDiscount) {
  return http.patch(`/discount/${id}`, { discount, name})
}

export function fetchProductOfDiscount(id: number) {
  return http.get(`/discount/${id}`)
}