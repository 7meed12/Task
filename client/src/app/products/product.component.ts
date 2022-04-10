import { Component, OnInit } from '@angular/core';
import { IProduct } from '../models/products';
import { ProductsService } from './productService.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  products: IProduct []=[];
  constructor(private productService : ProductsService) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(response=>{
      this.products=response;
    })
  }

}
