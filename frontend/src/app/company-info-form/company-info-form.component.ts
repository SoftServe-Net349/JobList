import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { Company } from '../shared/models/company.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
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
  uploadedFile: File;
  dataString: string|ArrayBuffer;
  base64: string;

  constructor(private formBuilder: FormBuilder,
              private companyService: CompanyService) {}

  ngOnInit() {

    this.companyInfoForm = this.getCompanyInfoFrorm();

  }

  getCompanyInfoFrorm(): FormGroup {

    return this.formBuilder.group({
      companyName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(200)]],
      bossName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(100)]],
      email: ['', [Validators.required, Validators.minLength(6), Validators.maxLength(254),
        Validators.pattern('^[A-Za-z0-9!#$%&\'*+\/=?^_`{|}~.-]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$')]],
      phone: [''],
      shortDescription: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(25)]],
      site: ['', [Validators.minLength(3), Validators.maxLength(100),
        Validators.pattern('^(http\:\/\/|https\:\/\/)?([a-z0-9][a-z0-9\-]*\.)+[a-z0-9][a-z0-9\-]*$')]],
      address: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(200)]],
      fullDescription: ['', [Validators.required]]
    });

  }

  showInformationForm(action: String, company: Company = null) {

    this.company = company;
    this.companyInfoForm.reset();
    this.display = true;
    this.action = action;
    this.uploadedFile = null;

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

    this.uploadedFile = event.files[0];
    const reader = new FileReader();

    reader.onload = () => {
     this.dataString = reader.result;
     this.base64 = this.dataString.toString().split(',')[1];
    };

    reader.readAsDataURL(this.uploadedFile);
    this.type = this.uploadedFile.type.toString().split('/')[1];

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
