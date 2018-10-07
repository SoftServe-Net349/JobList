
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
  SingInUser = false;
  SingInCompany = false;
  SingUpUser = false;
  SingUpCompany = false;
  SingInRecruiter = false;
  Information = false;

  AuthoruzationsForm: FormGroup;
  SingUpForUserForm: FormGroup;
  SingUpForCompany: FormGroup;
  AuthoruzationsForRecruiterForm: FormGroup;
  AuthoruzationsForCompanyForm: FormGroup;

  cities: City[];
  selectedCity: City;
ShowSingInUser() {
    this.SingInUser = true;
}
ShowSingInCompany() {
  this.SingInCompany = true;
}
ShowSingInRecruiter() {
  this.SingInRecruiter = true;
}
ShowSingUpUser() {
  this.SingUpUser = true;
  this.SingInUser = false;
}
ShowSingUpCompany() {
  this.SingUpCompany = true;
  this.SingInCompany = false;
}
CloseForm() {
    this.SingUpCompany = false;
    this.SingUpUser = false;
    this.Information = false;
    this.SingInUser = false;
    this.SingInRecruiter = false;
    this.SingInCompany = false;
  }
openInformation() {
    this.Information = true;
  }
loadCities() {
    this.cityService.getAll()
    .subscribe((data: City[]) => this.cities = data);
  }

  ngOnInit() {
    this.loadCities();
  }

  constructor(private formBuilder: FormBuilder,
    private cityService: CityService) {

      this.AuthoruzationsForm = this.formBuilder.group({
        login: ['', [Validators.required, Validators.email, Validators.minLength(2), Validators.maxLength(20)]],
        password: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(10)]],
      });
        this.AuthoruzationsForRecruiterForm = this.formBuilder.group({
        loginRcruiter: ['', [Validators.required, Validators.email, Validators.minLength(2), Validators.maxLength(20)]],
        passwordRecruiter: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(10)]],

      });
      this.AuthoruzationsForCompanyForm = this.formBuilder.group({
        loginCompany: ['', [Validators.required, Validators.email, Validators.minLength(2), Validators.maxLength(20)]],
        passwordCompany: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(10)]],

      });

      this.SingUpForUserForm = this.formBuilder.group({
        firstName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(20)]],
        lastName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(10)]],
        emailUser: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(16)]],
        passwordConfirm: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(16)]]
      });
      this.SingUpForCompany = this.formBuilder.group({
        nameCompany: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(20)]],
        nameBoss: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(10)]],
        nameStreet: ['', [Validators.required,  Validators.minLength(2), Validators.maxLength(20)]],
        numberBilding: ['', [Validators.required, Validators.pattern('^[0-9 .]{1,4}$')]],
        zipCode: ['', [Validators.required, Validators.pattern('^[0-9 .]{1,5}$')]],
        infoAboutCompany: ['', [Validators.required, Validators.minLength(30), Validators.maxLength(300)]],
        emailCompany: ['', [Validators.required, Validators.email]],
        passwordCompany: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(16)]],
        passwordConfirmCompany: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(16)]]

      });
    }

  }
