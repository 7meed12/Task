export interface IBasketItem {
    id: number;
    productName: string;
    price: number;
    quantity: number;
    pictureUrl: string;
    brand: string;
    type: string;
}

export interface IBasket {
    id: string;
    basketItems: IBasketItem[];
} 

export interface IBasketTotals{
    
     total: number;
}
