import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styles: [
  ]
})
export class RegisterComponent implements OnInit {
  registerForm:FormGroup;

  constructor(private fb : FormBuilder , private accoutService: AccountService, private router : Router) { }

  ngOnInit(): void {
    this.createRegisterForm();
  }
  onSubmit(){
    this.accoutService.register(this.registerForm.value).subscribe(()=>{
      this.router.navigateByUrl('/shop');
    });
  }
createRegisterForm(){
  this.registerForm=this.fb.group({
    username: ['',[Validators.required]],
    email: ['',[Validators.required, Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]],
    password: ['',[Validators.required]],
  })
}}
