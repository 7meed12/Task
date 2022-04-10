import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IProduct } from '../models/products';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {
  baseUrl='https://localhost:5001/api/'
  constructor(private http:HttpClient) { }
  getProducts(){
    return this.http.get<IProduct[]>(this.baseUrl+'product/getall')
  }
}
