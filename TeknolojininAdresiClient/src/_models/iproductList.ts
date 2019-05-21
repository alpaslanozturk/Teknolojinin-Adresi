export interface IproductList {
    productId: number;
    productName: string;
    unitPrice: number;
    oldPrice?: number;
    addedDate: Date;
    unitsInStock: number;
    sellCount: number;
}
