export interface IproductsTopSelling {
    productId: number;
    productName: string;
    unitPrice: number;
    oldPrice?: number;
    pictureUrl: string;
    addedDate: Date;
    totalRating: number;
    categoryName: string;
}
