import { http } from ".";

export function getSimilarProducts(productId: number){
  return http.get(`/Recommender/${productId}`);
};

export function updateRecommener() {
  return http.post(`/Recommender`);
}