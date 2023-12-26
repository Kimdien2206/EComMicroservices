import { http } from "..";

export function updateForecastData() {
  return http.post("/forecast");
}

export function getForecastByProductId(productId: string) {
  return http.get(`/forecast/${productId}`)
}