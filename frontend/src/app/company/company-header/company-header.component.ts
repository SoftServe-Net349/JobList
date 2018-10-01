import { Component, OnInit, ViewChild, Input } from '@angular/core';
import {MenuItem} from 'primeng/api';
import { CompanyInfoFormComponent } from '../../company-info-form/company-info-form.component';
import { Company } from '../../shared/models/company.model';

@Component({
  selector: 'app-company-header',
  templateUrl: './company-header.component.html',
  styleUrls: ['./company-header.component.sass']
})
export class CompanyHeaderComponent implements OnInit {

  visibleSidebar2;
  items: MenuItem[];

  @Input()
  company: Company;

  @ViewChild(CompanyInfoFormComponent)
  companyInfoForm: CompanyInfoFormComponent;

  constructor() { }

  ngOnInit() {
    this.items = [
      {
        label: 'Home',
        icon: 'fa fa-home'
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
