import { http } from "..";
import ICollection from "../../interface/Collection";

export function deleteCollection({id} : ICollection) {
  return http.delete(`/collection/${id}`)
}

export function updateCollection({ id, name, discountID }: ICollection) {
  return http.put(`/collection/${id}`, {
    name,
    discountID: discountID ? discountID : undefined,
    // products: []
  })
}

export function createCollection({ name, discountID }: ICollection) {
  return http.post(`/collection`, { name, discountID });
}