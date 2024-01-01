import { IImporting } from "./Importing";
import IProduct from "./Product";
import IProduct_item from "./ProductItem";


export interface IImportDetail{
    id: number;
    item: number;
    quantity: number;
    price: number;
    importID: number
    totalCost: number
    import: IImporting;
    product: IProduct      
}