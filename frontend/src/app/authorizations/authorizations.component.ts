import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { AuthService } from '../core/services/auth.service';
import { LoginRequest } from '../shared/models/login-request.model';
import { AuthHelper } from '../shared/helpers/auth-helper';
import { EmployeeRequest } from '../shared/models/employee-request.model';
import { Employee } from '../shared/models/employee.model';
import { CompanyRequest } from '../shared/models/company-request.model';
import { Company } from '../shared/models/company.model';
import { City } from '../shared/models/city.model';
import { CityService } from '../core/services/city.service';
import { sha512_224 } from 'js-sha512';
import { Router } from '@angular/router';

@Component({
  selector: 'app-authorizations',
  templateUrl: './authorizations.component.html',
  styleUrls: ['./authorizations.component.sass']
})

export class AuthorizationsComponent implements OnInit {

  signInDialog = false;
  signUpEmployee = false;
  signUpCompany = false;
  information = false;
  isLoading = false;

  role: string;
  errorMessage: string;
  cities: City[];
  selectedCity: City;
  birthDate: Date;

  authoruzationsForm: FormGroup;
  signUpEmployeeForm: FormGroup;
  signUpCompanyForm: FormGroup;

  uploadedFile: File;
  type: string;
  dataString: string | ArrayBuffer;
  base64: string;

  @Output()
  chengeAuthenticatedStatus = new EventEmitter();

  constructor(private formBuilder: FormBuilder,
              private authService: AuthService,
              private authHelper: AuthHelper,
              private cityService: CityService,
              private router: Router) {}

  ngOnInit() {

    this.loadCities();

    this.authoruzationsForm = this.getAuthoruzationForm();
    this.signUpEmployeeForm = this.getSignUpEmployeeForm();
    this.signUpCompanyForm = this.getSignUpCompanyForm();

  }

  loadCities() {

    this.cityService.getAll()
    .subscribe((data: City[]) => this.cities = data);
  }

  getAuthoruzationForm(): FormGroup {

    return this.formBuilder.group({
      login: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });

  }

  getSignUpEmployeeForm(): FormGroup {

    return this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(50),
        Validators.pattern('^[a-zA-Z ]*$')]],
      lastName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(50),
        Validators.pattern('^[a-zA-Z ]*$')]],
      email: ['', [Validators.required, Validators.email, Validators.minLength(6), Validators.maxLength(254),
        Validators.pattern('^[A-Za-z0-9!#$%&\'*+\/=?^_`{|}~.-]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$')]],
      birthDate: ['', [Validators.required]],
      city: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(100)]],
      passwordConfirm: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(100)]],
      checkedAgreementEmployee: [false, Validators.required]
    });

  }

  getSignUpCompanyForm(): FormGroup {

    return this.formBuilder.group({
      companyName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(200),
        Validators.pattern('^[a-zA-Z ]*$')]],
      bossName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(100)]],
      email: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(254),
        Validators.pattern('^[A-Za-z0-9!#$%&\'*+\/=?^_`{|}~.-]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$')]],
      phone: [''],
      shortDescription: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(25)]],
      site: ['', [Validators.minLength(3), Validators.maxLength(100),
      Validators.pattern('^(http\:\/\/|https\:\/\/)?([a-z0-9][a-z0-9\-]*\.)+[a-z0-9][a-z0-9\-]*$')]],
      address: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(200)]],
      fullDescription: ['', [Validators.required]],
      password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(100)]],
      passwordConfirm: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(100)]],
      checkedAgreement: [false, Validators.required]
    });

  }

  showSignIn(_role: string, _login = '') {

    this.errorMessage = '';
    this.authoruzationsForm.reset();
    this.role = _role;
    this.authoruzationsForm.setValue({ login: _login, password: '' });
    this.signInDialog = true;

  }

  showSignUpEmployee() {

    this.errorMessage = '';
    this.signUpEmployeeForm.reset();
    this.signInDialog = false;
    this.signUpEmployee = true;

  }

  showSignUpCompany() {

    this.errorMessage = '';
    this.signUpCompanyForm.reset();
    this.signInDialog = false;
    this.signUpCompany = true;

  }

  closeForm() {
    this.signUpCompany = false;
    this.signUpEmployee = false;
  }

  closeInformationForm() {
    this.information = false;
  }

  openInformation() {
    this.information = true;
  }

  submitSignIn() {

    const request: LoginRequest = {
      email: this.authoruzationsForm.get('login').value,
      password: sha512_224(this.authoruzationsForm.get('password').value).toString()
    };

    if (this.role === 'Employee') {

      this.authService.employeeLogin(request)
        .subscribe(token => {
          this.authHelper.setToken(token);
          this.chengeAuthenticatedStatus.emit();
          this.errorMessage = '';
          this.signInDialog = false;
        },
          error => { this.errorMessage = error.error; }
        );

    } else if (this.role === 'Company') {

      this.authService.companyLogin(request)
        .subscribe(token => {
          this.authHelper.setToken(token);
          this.chengeAuthenticatedStatus.emit();
          this.errorMessage = '';
          this.signInDialog = false;
        },
          error => { this.errorMessage = error.error; }
        );

    } else if (this.role === 'Recruiter') {

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

  submitEmployeeSignUp() {

    const request: EmployeeRequest = this.getEmployeeRequest();

    this.authService.employeeSignUp(request).subscribe(

      (data: Employee) => {
        this.errorMessage = '';
        this.signUpEmployee = false;
        this.showSignIn('Employee', data.email); },

      error => { this.errorMessage = error.error; }
    );
  }

  getEmployeeRequest(): EmployeeRequest {

    return {
      firstName: this.signUpEmployeeForm.get('firstName').value,
      lastName: this.signUpEmployeeForm.get('lastName').value,
      email: this.signUpEmployeeForm.get('email').value,
      password: sha512_224(this.signUpEmployeeForm.get('password').value).toString(),
      birthDate: this.birthDate,
      cityId: this.selectedCity.id,
      phone: null,
      photoData: null,
      photoMimeType: null,
      roleId: 2,
      sex: ''
    };

  }

  submitCompanySignUp() {

    const request: CompanyRequest = this.getCompanyRequest();

    this.authService.companySignUp(request).subscribe(
      (data: Company) => {
        this.errorMessage = '';
        this.signUpCompany = false;
        this.showSignIn('Company', data.email);
      },
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
      password: sha512_224(this.signUpCompanyForm.get('password').value).toString(),
      logoData: this.base64,
      logoMimetype: this.type,
      phone: this.signUpCompanyForm.get('phone').value,
      roleId: 3,
      shortDescription: this.signUpCompanyForm.get('shortDescription').value,
      site: this.signUpCompanyForm.get('site').value
    };

  }

  onUpload(event) {

    this.uploadedFile = event.files[0];
    const reader = new FileReader();

    reader.onload = () => {
      this.dataString = reader.result;
      this.base64 = this.dataString.toString().split(',')[1];
    };

    reader.readAsDataURL(this.uploadedFile);
    this.type = this.uploadedFile.type.toString().split('/')[1];

  }

  signInWithFacebook() {

    this.isLoading = true;

    this.authService.signInWithFacebook()
    .then((res: any) => {

     this.authService.employeeFacebookLogin(res.credential.accessToken)
     .subscribe(token => {
      this.authHelper.setToken(token);
      this.chengeAuthenticatedStatus.emit();
      this.errorMessage = '';
      this.isLoading = false;
      location.replace('/');

      },
        error => { this.errorMessage = error.error; this.isLoading = false; }
      );
    })
    .catch((err) => {console.log(err); this.isLoading = false; });
  }

}
