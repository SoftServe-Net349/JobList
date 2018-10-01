import { Component, OnInit } from '@angular/core';
import { Company } from '../shared/models/company.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MessageService } from 'primeng/api';

@Component({
  selector: 'app-company-info-form',
  templateUrl: './company-info-form.component.html',
  styleUrls: ['./company-info-form.component.sass']
})
export class CompanyInfoFormComponent implements OnInit {

  companyInfoForm: FormGroup;

  display: Boolean = false;
  action: String;

  uploadedFiles: any[] = [];

  company: Company;

  constructor(private formBuilder: FormBuilder,
              private messageService: MessageService) {

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
      role: {id: 1, name: ''},
      recruiters: []
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

}
