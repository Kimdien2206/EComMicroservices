import ForecastDetail from "./ForecastDetail";

export default interface Forecast {
    id: number;
    lastUpdated: Date;
  productId: number;
  details: ForecastDetail[]
}

