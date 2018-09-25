import { Component, OnInit } from '@angular/core';
import {MenuItem} from 'primeng/api';

@Component({
  selector: 'app-company-header',
  templateUrl: './company-header.component.html',
  styleUrls: ['./company-header.component.sass']
})
export class CompanyHeaderComponent implements OnInit {
	
	visibleSidebar2
	items: MenuItem[];

	constructor() { }

	ngOnInit() {
		this.items = [
			{
				label: 'Find Resumes', 
				icon: 'fa fa-search-plus'
			},
			{
				label: 'Update Info', 
				icon: 'fa fa-pencil-square-o'
			},
			{
				label: 'Add Recruiter', 
				icon: 'fa fa-plus'
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
