import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Company } from '../shared/models/company.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';
import { CompanyRequest } from '../shared/models/company-request.model';
import { CompanyService } from '../core/services/company.service';

@Component({
  selector: 'app-company-info-form',
  templateUrl: './company-info-form.component.html',
  styleUrls: ['./company-info-form.component.sass']
})
export class CompanyInfoFormComponent implements OnInit {

  @Output() loadCompanyById = new EventEmitter();
  companyInfoForm: FormGroup;

  display: Boolean = false;
  action: String;

  uploadedFiles: any[] = [];

  company: Company;

  constructor(private formBuilder: FormBuilder,
              private messageService: MessageService,
              private companyService: CompanyService) {

    this.company = this.defaultCompany();

    this.companyInfoForm = this.formBuilder.group({
      companyName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      bossName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      email: ['', [Validators.required, Validators.email, Validators.minLength(5), Validators.maxLength(150)]],
      phone: [''],
      shortDescription: ['', [Validators.minLength(2), Validators.maxLength(25)]],
      site: ['', [Validators.minLength(2), Validators.maxLength(100),
        Validators.pattern('^(http\:\/\/|https\:\/\/)?([a-z0-9][a-z0-9\-]*\.)+[a-z0-9][a-z0-9\-]*$')]],
      address: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      fullDescription: ['']
    });
  }

  ngOnInit() {
  }

  defaultCompany(): Company {
    return {
      id: 0, name: '',
      bossName: '',
      fullDescription: '',
      shortDescription: '',
      address: '',
      phone: '',
      logoData: [],
      logoMimetype: '',
      site: '',
      email: '',
      password: '',
      roleId: 0
    };
  }

  showInformationForm(action: String, company: Company = this.defaultCompany()) {
    this.company = company;
    this.companyInfoForm.reset();
    this.display = true;
    this.action = action;
    if (action === 'Update') {
      this.companyInfoForm.setValue({
        companyName: this.company.name,
        bossName: this.company.bossName,
        email: this.company.email,
        phone: this.company.phone,
        shortDescription: this.company.shortDescription,
        site: this.company.site,
        address: this.company.address,
        fullDescription: this.company.fullDescription
      });
    }

 }

 onUpload(event) {
  for (const file of event.files) {
    this.uploadedFiles.push(file);
  }

  this.messageService.add({severity: 'info', summary: 'File Uploaded', detail: ''});
  }

  submit() {
    if (this.action === 'Update') {
      this.updateCompanyInfo();
    }
    this.display = false;
  }

  updateCompanyInfo() {
    const request: CompanyRequest = {
        name: this.companyInfoForm.get('companyName').value,
        bossName: this.companyInfoForm.get('bossName').value,
        email: this.companyInfoForm.get('email').value,
        phone: this.companyInfoForm.get('phone').value,
        shortDescription: this.companyInfoForm.get('shortDescription').value,
        site: this.companyInfoForm.get('site').value,
        address: this.companyInfoForm.get('address').value,
        fullDescription: this.companyInfoForm.get('fullDescription').value,
        password: this.company.password,
        roleId: this.company.roleId,
        logoData: this.company.logoData,
        logoMimetype: this.company.logoMimetype
    };

    this.companyService.update(this.company.id, request)
    .subscribe(data => this.loadCompanyById.emit());
  }

}
