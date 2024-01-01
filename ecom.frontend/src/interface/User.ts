import IAccount from "./Account";
import ICart from "./Cart";
import { IFeedback } from "./Feedback";
import IOrder from "./Order";
import IReceipt from "./Receipt";
import IReview from "./Review";

export default interface IUser {
  id: number;
  firstname?: string;
  lastname?: string;
  phoneNumber?: string;
  address?: string;
  avatar?: string;
  logged_date: Date;
  product_viewed?: string[];
  account?: IAccount;
  email: string;
  Feedback?: IFeedback[];
  Review?: IReview[];
  Cart?: ICart[];
  Order?: IOrder[];
  Receipt?: IReceipt[];
}