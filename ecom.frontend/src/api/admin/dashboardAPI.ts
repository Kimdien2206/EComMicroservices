import { http } from "..";

export function fetchReport(year: string) {
    return http.get(`/report/yearly/${year}`);
}

export function fetchTopTenBestSellers() {
    return http.get(`/product/best-sellers`);
}
  
export function fetchTopTenMostViewed() {
    return http.get(`/product/most-viewed`);
}