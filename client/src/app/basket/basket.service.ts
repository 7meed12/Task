import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { BehaviorSubject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IBasket, IBasketItem, IBasketTotals } from '../models/basket';
import { Basket } from '../models/Basket.1';
import { IProduct } from '../models/products';

@Injectable({
  providedIn: 'root'
})
export class BasketService {

  baseUrl=environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>(null);
  basket$=this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<IBasketTotals>(null);
  basketTotal$=this.basketTotalSource.asObservable();

  constructor(private http:HttpClient) { }
  getBasket(id:string ){
    return this.http.get(this.baseUrl+'basket?id='+id).pipe(
      map((basket:IBasket)=>{
        this.basketSource.next(basket);
        this.calcTotal();
        
      } )
    )
  };  

  setBasket(basket:IBasket){
    return this.http.post(this.baseUrl+'basket',basket).subscribe((response:IBasket)=>{
      this.basketSource.next(response);
      this.calcTotal();
    });
  };

  getCurrentBasketValue(){
    return this.basketSource.value;
  };

  incrementItemQuantity(item:IBasketItem){
    const basket=this.getCurrentBasketValue();
    const foundItemIndex=basket.basketItems.findIndex(x=>x.id===item.id);
    basket.basketItems[foundItemIndex].quantity++;
    this.setBasket(basket);
  }
  decrementItemQuantity(item:IBasketItem){
    const basket=this.getCurrentBasketValue();
    const foundItemIndex=basket.basketItems.findIndex(x=>x.id===item.id);
    if(basket.basketItems[foundItemIndex].quantity>1){
      basket.basketItems[foundItemIndex].quantity--;
      this.setBasket(basket);
    }else{
      this.removeItemFromTheBasket(item);
    }
  }
  removeItemFromTheBasket(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    if(basket.basketItems.some(x=>x.id===item.id)){
      basket.basketItems=basket.basketItems.filter(i=>i.id!==item.id);
      if(basket.basketItems.length>0){
        this.setBasket(basket);
      }else{
        this.deleteBasket(basket);
      }
    }
  }
  deleteBasket(basket: IBasket) {
    return this.http.delete(this.baseUrl+'basket?id='+basket.id).subscribe(()=>{this.basketSource.next(null);
      this.basketTotalSource.next(null);
      localStorage.removeItem('basket_id');
  });}
  addItemToBasket(item:IProduct , quantity = 1 ){
      const itemToAdd:IBasketItem= this.mapProductToBasket(item,quantity);
      const basket=this.getCurrentBasketValue() ?? this.createBasket(); 
      basket.basketItems=this.addOrUpdateItems(basket.basketItems,itemToAdd,quantity); 
      this.setBasket(basket);
  };

  addOrUpdateItems(basketItems: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    const index = basketItems.findIndex(i => i.id === itemToAdd.id);
    if(index==-1) {
      itemToAdd.quantity=quantity;
      basketItems.push(itemToAdd);
  } else {
    basketItems [index].quantity+= quantity;
  }
  return basketItems;
};

  private createBasket(): IBasket {
   const basket= new Basket();
   localStorage.setItem('basket_id',basket.id);
   return basket;
  };
  
  private mapProductToBasket(item: IProduct, quantity: number): IBasketItem {
    return {
      id:item.id,
      productName:item.name,
      price:item.price,
      pictureUrl:item.pictureUrl,
      quantity,
      brand:item.productBrand,
      type:item.productType
    }
  };
  private calcTotal(){
    const basket = this.getCurrentBasketValue();
    const total=basket.basketItems.reduce((acc,item)=>acc+item.quantity*item.price,0);
    this.basketTotalSource.next({total});
  }
}
 

