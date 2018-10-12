import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup,  FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../core/services/auth.service';
import { LoginRequest } from '../shared/models/login-request.model';
import { AuthHelper } from '../shared/helpers/auth-helper';
import { UserRequest } from '../shared/models/user-request.model';
import { User } from '../shared/models/user.model';
import { CompanyRequest } from '../shared/models/company-request.model';
import { Company } from '../shared/models/company.model';

@Component({
  selector: 'app-authorizations',
  templateUrl: './authorizations.component.html',
  styleUrls: ['./authorizations.component.sass']
})

export class AuthorizationsComponent implements OnInit {

  signInDialog = false;

  signUpUser = false;
  signUpCompany = false;
  information = false;

  role: string;
  errorMessage: string;

  authoruzationsForm: FormGroup;
  signUpUserForm: FormGroup;
  signUpCompanyForm: FormGroup;

  @Output()
  chengeAuthenticatedStatus = new EventEmitter();

  constructor(private formBuilder: FormBuilder,
              private authService: AuthService,
              private authHelper: AuthHelper) {

  }

  ngOnInit() {
    this.authoruzationsForm = this.getAuthoruzationForm();
    this.signUpUserForm = this.getSignUpUserForm();
    this.signUpCompanyForm = this.getSignUpCompanyForm();

  }

  getAuthoruzationForm(): FormGroup {
    return this.formBuilder.group({
      login: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }

  getSignUpUserForm(): FormGroup {
    return this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email, Validators.minLength(2), Validators.maxLength(150)]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(100)]],
      passwordConfirm: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(100)]]
    });
  }

  getSignUpCompanyForm(): FormGroup {
    return this.formBuilder.group({
      companyName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      bossName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      address: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      fullDescription: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email, Validators.minLength(2), Validators.maxLength(150)]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(100)]],
      passwordConfirm: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(100)]]
    });
  }

  showSignIn(_role: string, _login = '', _password = '') {
    this.authoruzationsForm.reset();
    this.role = _role;
    this.authoruzationsForm.setValue({login: _login, password: _password});
    this.signInDialog = true;
  }

  showSignUpUser() {
    this.signUpUserForm.reset();
    this.signInDialog = false;
    this.signUpUser = true;
  }

  showSignUpCompany() {
    this.signUpCompanyForm.reset();
    this.signInDialog = false;
    this.signUpCompany = true;
  }

  closeForm() {
    this.signUpCompany = false;
    this.signUpUser = false;
    this.information = false;
  }

  openInformation() {
    this.information = true;
  }

  submitSignIn() {
    const request: LoginRequest = {
      email: this.authoruzationsForm.get('login').value,
      password: this.authoruzationsForm.get('password').value
    };
    if (this.role === 'User') {
      this.authService.userLogin(request)
      .subscribe(token => {
        this.authHelper.setToken(token);
        this.chengeAuthenticatedStatus.emit();
        this.errorMessage = '';
        this.signInDialog = false;
      },
      error => { this.errorMessage = error.error; }
      );
    }
    if (this.role === 'Company') {
      this.authService.companyLogin(request)
      .subscribe(token => {
        this.authHelper.setToken(token);
        this.chengeAuthenticatedStatus.emit();
        this.errorMessage = '';
        this.signInDialog = false;
      },
      error => { this.errorMessage = error.error; }
      );
    }
    if (this.role === 'Recruiter') {
      this.authService.recruiterLogin(request)
      .subscribe(token => {
        this.authHelper.setToken(token);
        this.chengeAuthenticatedStatus.emit();
        this.errorMessage = '';
        this.signInDialog = false;
      },
      error => { this.errorMessage = error.error; }
      );
    }
  }

  submitUserSignUp() {
    const request: UserRequest = this.getUserRequest();

    this.authService.userSignUp(request).subscribe(
      (data: User) => {
        this.errorMessage = '';
        this.signUpUser = false;
        this.showSignIn('User', data.email, data.password); },
      error => { this.errorMessage = error.error; }
      );
  }

  getUserRequest(): UserRequest {
    return {
      firstName: this.signUpUserForm.get('firstName').value,
      lastName: this.signUpUserForm.get('lastName').value,
      email: this.signUpUserForm.get('email').value,
      password: this.signUpUserForm.get('password').value,
      birthData: null,
      cityId: null,
      phone: null,
      photoData: null,
      photoMimeType: null,
      roleId: 2,
      sex: null
    };
  }

  submitCompanySignUp() {
    const request: CompanyRequest = this.getCompanyRequest();

    this.authService.companySignUp(request).subscribe(
      (data: Company) => {
        this.errorMessage = '';
        this.signUpCompany = false;
        this.showSignIn('Company', data.email, data.password); },
      error => { this.errorMessage = error.error; }
      );
  }

  getCompanyRequest(): CompanyRequest {
    return {
      name: this.signUpCompanyForm.get('companyName').value,
      bossName: this.signUpCompanyForm.get('bossName').value,
      address: this.signUpCompanyForm.get('address').value,
      fullDescription: this.signUpCompanyForm.get('fullDescription').value,
      email: this.signUpCompanyForm.get('email').value,
      password: this.signUpCompanyForm.get('password').value,
      logoData: null,
      logoMimetype: null,
      phone: null,
      roleId: 3,
      shortDescription: null,
      site: null
    };
  }

}
