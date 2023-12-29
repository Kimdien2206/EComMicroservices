import IAccount from '../interface/Account';
import IUser from '../interface/User';
import { http } from './index';

export const createAccount = (email: string, password: string, user: IUser) => {
  return http.post('/Auth/register', {
    email, password,
    user: {
      ...user
    }
  });
};

export const resetPassword = (email: string) => {
  return http.patch(`/accounts/password-reset/${email}`);
}

export const updatePassword = (email: string, password: string) => {
  return http.patch(`/accounts/${email}`, { password });
}

export const getAccount = (email: string) => {
  return http.get(`/accounts/${email}`)
}