import { Component, OnInit,  Input } from '@angular/core';
import { MenuItem } from 'primeng/api';
import { Recruiter } from '../../shared/models/recruiter.model';

@Component({
  selector: 'app-recruiter-header',
  templateUrl: './recruiter-header.component.html',
  styleUrls: ['./recruiter-header.component.sass']
})
export class RecruiterHeaderComponent implements OnInit {

  visibleSidebar2;
  items: MenuItem[];


  @Input()
  recruiter: Recruiter

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
      {label: 'Something1', icon: 'pi pi-fw pi-user-plus'},
      {label: 'Something2', icon: 'pi pi-fw pi-filter'}
      ]
    },
    {
    label: 'Sign out',
    icon: 'fa fa-sign-out'
    }
    ];
  }

}
