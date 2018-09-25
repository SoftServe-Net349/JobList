import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';
import {MenuItem} from 'primeng/api';
import { CompanyInfoFormComponent } from '../../company-info-form/company-info-form.component';
import { RecruiterFormComponent } from '../../recruiter-form/recruiter-form.component';

@Component({
  selector: 'app-company-header',
  templateUrl: './company-header.component.html',
  styleUrls: ['./company-header.component.sass']
})
export class CompanyHeaderComponent implements OnInit {

  visibleSidebar2;
  items: MenuItem[];

  @Input('recruiterForm')
  recruiterForm: RecruiterFormComponent;

  @ViewChild(CompanyInfoFormComponent)
  companyInfoForm: CompanyInfoFormComponent;

  constructor() { }

  ngOnInit() {
    this.items = [
      {
        label: 'Find Resumes',
        icon: 'fa fa-search-plus'
      },
      {
        label: 'Update Info',
        icon: 'fa fa-pencil-square-o',
        command: (event) => { this.companyInfoForm.showInformationForm('Update'); }
      },
      {
        label: 'Add Recruiter',
        icon: 'fa fa-plus',
        command: (event) => { this.recruiterForm.showRecruiterForm('Create'); }
      },
      {
        label: 'Settings',
        icon: 'fa fa-cog',
        items: [
          {label: 'Change password', icon: 'pi pi-fw pi-user-plus'},
          {label: 'Change login', icon: 'pi pi-fw pi-filter'}
        ]
      },
      {
      label: 'Sign out',
      icon: 'fa fa-sign-out'
      }
    ];
  }

}
