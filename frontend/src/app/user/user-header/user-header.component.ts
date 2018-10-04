import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';
import {MenuItem} from 'primeng/api';
// import { RecruiterFormComponent } from '../../recruiter-form/recruiter-form.component';

@Component({
  selector: 'app-user-header',
  templateUrl: './user-header.component.html',
  styleUrls: ['./user-header.component.sass']
})
export class UserHeaderComponent implements OnInit {

  visibleSidebar2;
  items: MenuItem[];

  // @Input('recruiterForm')
  // recruiterForm: RecruiterFormComponent;

  constructor() { }

  ngOnInit() {
    this.items = [
      {
        label: 'Find Vacancies',
        icon: 'fa fa-search-plus'
      },
      // {
      //   label: 'Add Recruiter',
      //   icon: 'fa fa-plus',
      //   command: (event) => { this.recruiterForm.showRecruiterForm('Create'); }
      // },
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
