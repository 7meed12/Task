import { Component, ElementRef, Input, NgModule, OnInit, Self, ViewChild } from '@angular/core';
import { ControlValueAccessor, NgControl } from '@angular/forms';

@Component({
  selector: 'app-text-inputs',
  templateUrl: './text-inputs.component.html',
  styleUrls: ['./text-inputs.component.scss']
})
export class TextInputsComponent implements OnInit , ControlValueAccessor {
@ViewChild('input') input:ElementRef;
@Input()type='text';
@Input()label:string;
  constructor(@Self() public controlDir:NgControl) { 
    this.controlDir.valueAccessor=this;
  }
  onChange(event){
    
  }
  onTouched(){}
  writeValue(obj: any): void {
    this.input.nativeElement.value=obj||'';
  }
  registerOnChange(fn: any): void {
    this.onChange=fn; 
  }
  registerOnTouched(fn: any): void {
    this.onTouched=fn;
  }
  

  ngOnInit(): void {
    const control = this.controlDir.control;
    const validators = control.validator ? [control.validator] : [];
    control.setValidators(validators);
    control.updateValueAndValidity();
  }

}