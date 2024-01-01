import axios, { AxiosResponse } from 'axios';
export const http = axios.create({
  baseURL: 'https://localhost:1205/api',
  timeout: 100000,
  headers: {
    Authorization: localStorage.getItem('access_token') ? `Bearer ${localStorage.getItem('access_token')}` : undefined
  },
});

http.interceptors.response.use(
  (response: AxiosResponse) => response,
  (error: any) => {
    const status = error.response ? error.response.status : 0;
    const message =
      error.response && error.response.data.message
        ? error.response.data.message
        : 'Hệ thống gặp sự cố, thử lại sau!!';

  if (status >= 500 && status <= 599) {
        // notification.error({
        //   message: 'Hệ thống gặp sự cố, thử lại sau!!',
        //   duration: 10
        // });
        console.log(status)
      }

    return Promise.reject(error);
  }
);
