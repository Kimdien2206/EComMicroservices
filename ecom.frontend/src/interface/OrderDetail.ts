import IOrder from "./Order";
import IProduct from "./Product";
import IProduct_item from "./ProductItem";

export default interface IOrder_detail {
  id: number;
  product_item: IProduct_item;
  product: IProduct;
  itemId: number;
  order: IOrder;
  quantity: number;
  orderID: number;
}