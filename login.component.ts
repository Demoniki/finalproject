import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from 'src/app/models/LoginModel';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(public lservice:LoginService,private router:Router) { }

  ngOnInit(): void {
  }
loginMethod(form:NgForm)
{
  this.insertdata(form);
}
insertdata(myForm:NgForm)
{
this.lservice.loginMethod().subscribe(d=>{
  this.resetform(myForm);
  console.log('login successful------');
  this.router.navigate(['grocery'])
},
error=>{
  console.log('invalid input');
});

}
resetform(myform:NgForm)
{
  myform.form.reset();
  this.lservice.data=new LoginModel();
}
}
