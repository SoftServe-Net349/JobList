import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Company } from '../shared/models/company.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { MessageService, MenuItem } from 'primeng/api';
import { CompanyService } from '../core/services/company.service';
import { CompanyUpdateRequest } from '../shared/models/company-update-request.model';

@Component({
  selector: 'app-company-info-form',
  templateUrl: './company-info-form.component.html',
  styleUrls: ['./company-info-form.component.sass']
})
export class CompanyInfoFormComponent implements OnInit {

  @Output() loadCompanyById = new EventEmitter();

  @Input()
  company: Company;

  companyInfoForm: FormGroup;

  display: Boolean = false;
  action: String;

  type: string;
  uploadedFiles: any[] = [];
  dataString: string|ArrayBuffer;
  base64: string;

  constructor(private formBuilder: FormBuilder,
              private messageService: MessageService,
              private companyService: CompanyService) {

  }

  ngOnInit() {

    this.companyInfoForm = this.getCompanyInfoFrorm();

  }

  getCompanyInfoFrorm(): FormGroup {

    return this.formBuilder.group({
      companyName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      bossName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      email: ['', [Validators.required, Validators.email, Validators.minLength(5), Validators.maxLength(150)]],
      phone: [''],
      shortDescription: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(25)]],
      site: ['', [Validators.minLength(2), Validators.maxLength(100),
        Validators.pattern('^(http\:\/\/|https\:\/\/)?([a-z0-9][a-z0-9\-]*\.)+[a-z0-9][a-z0-9\-]*$')]],
      address: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      fullDescription: ['', [Validators.required]]
    });

  }

  showInformationForm(action: String, company: Company = null) {

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
      this.base64 = this.company.logoData;
      this.type = this.company.logoMimetype;
    }

  }

  onUpload(event) {
    for (const file of event.files) {
    this.uploadedFiles.push(file);
     const reader = new FileReader();
     reader.onload = () => {
     this.dataString = reader.result;
     this.base64 = this.dataString.toString().split(',')[1];
    };
    reader.readAsDataURL(file);
    this.type = file.type.toString().split('/')[1];

   }
  }

  submit() {

    if (this.action === 'Update') {

      this.updateCompanyInfo();

    }

    this.display = false;

  }

  updateCompanyInfo() {

    const request: CompanyUpdateRequest = {
      name: this.companyInfoForm.get('companyName').value,
      bossName: this.companyInfoForm.get('bossName').value,
      email: this.companyInfoForm.get('email').value,
      phone: this.companyInfoForm.get('phone').value,
      shortDescription: this.companyInfoForm.get('shortDescription').value,
      site: this.companyInfoForm.get('site').value,
      address: this.companyInfoForm.get('address').value,
      fullDescription: this.companyInfoForm.get('fullDescription').value,
      roleId: this.company.role.id,
      logoData: this.base64,
      logoMimetype: this.type
    };
    this.companyService.update(this.company.id, request)
    .subscribe(data => this.loadCompanyById.emit());

  }

}
