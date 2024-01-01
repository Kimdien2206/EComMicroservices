import ICollection from "./Collection";
import IProduct from "./Product";
import ITag from "./Tag";


export default interface IDiscount {
  id: number;
  discountAmount: number;
  name: string;
  Tag: ITag[];
  Collection: ICollection[];
  Product: IProduct[];
}