import { Component, OnInit } from '@angular/core';
import { MenuItem } from 'primeng/api';

@Component({
  selector: 'app-recruiter-header',
  templateUrl: './recruiter-header.component.html',
  styleUrls: ['./recruiter-header.component.sass']
})
export class RecruiterHeaderComponent implements OnInit {

	visibleSidebar2;
	items: MenuItem[];
    
	constructor() { }
  
	ngOnInit() {
	  this.items = [
		{
		  label: 'Find Resumes',
		  icon: 'fa fa-search-plus'
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
