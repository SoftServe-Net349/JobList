import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { MessageService } from 'primeng/api';
import { FormGroup,  FormBuilder, Validators } from '@angular/forms';
import { City } from '../shared/models/city.model';
import { CityService } from '../core/services/city.service';
import { AuthService } from '../core/services/auth.service';
import { UserLoginRequest } from '../shared/models/user-login-request.model';
import { AuthHelper } from '../shared/helpers/auth-helper';

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
  signUpForUserForm: FormGroup;
  signUpForCompany: FormGroup;

  @Output()
  chengeAuthenticatedStatus = new EventEmitter();

  ngOnInit() {
  }

  constructor(private formBuilder: FormBuilder,
              private authService: AuthService,
              private authHelper: AuthHelper) {

    this.authoruzationsForm = this.formBuilder.group({
      login: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });

    this.signUpForUserForm = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(20)]],
      lastName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(10)]],
      emailUser: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(16)]],
      passwordConfirm: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(16)]]
    });
    this.signUpForCompany = this.formBuilder.group({
      nameCompany: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(20)]],
      nameBoss: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(10)]],
      address: ['', [Validators.required]],
      fullDescription: ['', [Validators.required, Validators.minLength(30), Validators.maxLength(300)]],
      emailCompany: ['', [Validators.required, Validators.email]],
      passwordCompany: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(16)]],
      passwordConfirmCompany: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(16)]]
    });
  }

  showSignIn(_role: string) {
    this.role = _role;
    this.signInDialog = true;
  }

  showSignUpUser() {
    this.signInDialog = false;
    this.signUpUser = true;
  }

  showSignUpCompany() {
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
    const request: UserLoginRequest = {
      email: this.authoruzationsForm.get('login').value,
      password: this.authoruzationsForm.get('password').value
    };
    this.authService.login(request)
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
