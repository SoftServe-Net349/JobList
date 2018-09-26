import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-company-info-form',
  templateUrl: './company-info-form.component.html',
  styleUrls: ['./company-info-form.component.sass']
})
export class CompanyInfoFormComponent implements OnInit {

  display: Boolean = false;
  action: String;

  constructor() { }

  ngOnInit() {
  }

  showInformationForm(action: String) {
  this.display = true;
  this.action = action;
  }

}
