export interface IaddProduct {
    productId?: number;
    productName: string;
    unitPrice: number;
    oldPrice?: number;
    unitsInStock: number;
    pictureUrl: string;
    sellCount: number;
    categoriesId: number;
}
