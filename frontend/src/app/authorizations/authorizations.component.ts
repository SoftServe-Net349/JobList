import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { MessageService } from 'primeng/api';
import { FormGroup,  FormBuilder, Validators } from '@angular/forms';
import { City } from '../shared/models/city.model';
import { CityService } from '../core/services/city.service';

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

  authoruzationsForm: FormGroup;
  signUpForUserForm: FormGroup;
  signUpForCompany: FormGroup;

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


  ngOnInit() {
  }

  constructor(private formBuilder: FormBuilder) {

      this.authoruzationsForm = this.formBuilder.group({
        login: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(20)]],
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

  }
