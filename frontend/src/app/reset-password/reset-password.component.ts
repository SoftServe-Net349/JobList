import { Component, OnInit, Output, Input, EventEmitter } from '@angular/core';
import { Validators, FormGroup, FormBuilder } from '@angular/forms';
import { CompanyResetPasswordRequest } from '../shared/models/company-reset-password-request.model';
import { CompanyService } from '../core/services/company.service';
import { sha512_224 } from 'js-sha512';
import { Company } from '../shared/models/company.model';
import { Recruiter } from '../shared/models/recruiter.model';
import { RecruiterService } from '../core/services/recruiter.service';
import { EmployeeService } from '../core/services/employee.service';
import { Employee } from '../shared/models/employee.model';
import { EmployeeResetPasswordRequest } from '../shared/models/employee-reset-password-request.model';
import { RecruierResetPasswordRequest } from '../shared/models/recruiter-reset-password-request.model';

@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.sass']
})
export class ResetPasswordComponent implements OnInit {

  resetPasswordDialog = false;
  

  role: string;
  id:number;
  errorMessage: string;


  resetPasswordForm: FormGroup;

  @Output() loadCompanyById = new EventEmitter();
  @Input()
  company: Company;
 

  @Output() loadRecruiterById = new EventEmitter();
  @Input()
  recruiter: Recruiter;
 

  @Output() loadEmployeeById = new EventEmitter();
  @Input()
  employee: Employee;
 
  constructor(private formBuilder: FormBuilder,
               private companyService: CompanyService,
               private recruiterService: RecruiterService,
               private employeeService:EmployeeService) { }

  ngOnInit() {
    this.resetPasswordForm = this.getResetPasswordForm();
  }

  getResetPasswordForm(): FormGroup {

    return this.formBuilder.group({
      currentPassword: ['', [Validators.required]],
      newPassword: ['', [Validators.required,Validators.minLength(8), Validators.maxLength(100)]],
      confirmPassword:  ['', [Validators.required]],
    });

  }
  showSignIn(_role:string, _id:number) {

    this.errorMessage = '';
    this.resetPasswordForm.reset();
    this.resetPasswordDialog = true;
    this.role=_role;
    this.id=_id;

  }
  closeForm() {
    this.resetPasswordDialog = false;
  }

  resetPassword(role, id){
    if(role=='company'){
    const request: CompanyResetPasswordRequest = {
      currentPassword:sha512_224(this.resetPasswordForm.get('currentPassword').value).toString(),
      newPassword: sha512_224(this.resetPasswordForm.get('newPassword').value).toString()
      
    };
    this.companyService.reset(id,request)
    .subscribe(data => {
      this.loadCompanyById.emit();
      this.resetPasswordDialog=false;},
    error => { this.errorMessage = error.error; }
    )
    }
    if(role=='employee'){
      const request: EmployeeResetPasswordRequest = {
        currentPassword:sha512_224(this.resetPasswordForm.get('currentPassword').value).toString(),
        newPassword: sha512_224(this.resetPasswordForm.get('newPassword').value).toString()
        
      };
      this.employeeService.reset(id,request)
      .subscribe(data => {
        this.loadEmployeeById.emit();
        this.resetPasswordDialog=false;},
      error => { this.errorMessage = error.error; }
      )
      }
      if(role=='recruiter'){
        const request: RecruierResetPasswordRequest = {
          currentPassword:sha512_224(this.resetPasswordForm.get('currentPassword').value).toString(),
          newPassword: sha512_224(this.resetPasswordForm.get('newPassword').value).toString()
          
        };
        this.recruiterService.reset(id,request)
        .subscribe(data => {
          this.loadRecruiterById.emit();
          this.resetPasswordDialog=false;},
        error => { this.errorMessage = error.error; }
        )
        }
  }
}
