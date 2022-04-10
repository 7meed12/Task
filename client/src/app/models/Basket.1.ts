import { v4 as uuidv4 } from 'uuid';
import { IBasket, IBasketItem } from './basket';


export class Basket implements IBasket {
    id = uuidv4();
    basketItems: IBasketItem[]=[];
}
