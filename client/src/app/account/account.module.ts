import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AccountRoutingModule } from './account-routing.module';
import { ReactiveFormsModule } from '@angular/forms';

import { AppModule } from '../app.module';
import { TextInputsComponent } from './login/text-inputs/text-inputs.component';



@NgModule({
  declarations: [
    LoginComponent,
    RegisterComponent,
    TextInputsComponent
  ],
  imports: [
    CommonModule,
    AccountRoutingModule,
    ReactiveFormsModule,
  
  ]
})
export class AccountModule { }
