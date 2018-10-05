
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { MessageService } from 'primeng/api';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
@Component({
  selector: 'app-authorizations',
  templateUrl: './authorizations.component.html',
  styleUrls: ['./authorizations.component.sass']
})
export class AuthorizationsComponent implements OnInit {
  display = false;
  display1=false;
  display2=false;
  isSignIn = true;
  display3=false;
 
  
  
  
showDialog() {
    this.display = true;
}    
  
openSingUpUser() {
    this.display = false;
    this.display2=false;
    this.display1 = true;}
    
openSingUpUser1() {
    this.display = false;
    this.display1 = true;
    this.display2=false;

  }
 
  openSingUpCompany(){
    this.display = false;
    this.display2 = true;
    this.display1=false;
  }

  CloseForm(){
    this.display2 = false;
    this.display1=false;
    this.display=false;
  }
  CloseForm1(){
    this.display3 = false;
   
  }

  openInformation(){
    this.display3=true;
  }
  ngOnInit() {
  
  

  }

}
