import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './products/product.component';

const routes: Routes = [
  {path:'',component:ProductComponent},
  {path:'shop',component:ProductComponent},
  {path:'basket',loadChildren:()=>import('./basket/basket.module').then(mod=>mod.BasketModule)},
  {path:'account',loadChildren:()=>import('./account/account.module').then(mod=>mod.AccountModule)},
  
  {path:'**',redirectTo:'',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
