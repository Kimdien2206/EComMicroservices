import IOrder_detail from "./OrderDetail";
import IReceipt from "./Receipt";
import IUser from "./User";

export default interface IOrder {
  id: number;
  date: Date;
  totalCost: number;
  status: string;
  firstname: string;
  lastname: string;
  phoneNumber: string; 
  address: string;     
  buyer: IUser;
  userID: string;
  Receipt: IReceipt[];
  orderDetails: IOrder_detail[];
}