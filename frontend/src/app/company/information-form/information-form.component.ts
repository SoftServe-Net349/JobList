import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-information-form',
  templateUrl: './information-form.component.html',
  styleUrls: ['./information-form.component.sass']
})
export class InformationFormComponent implements OnInit {

  display: Boolean = false;
  action: String

  constructor() { }

  ngOnInit() {
  }

  showInformationForm(action: String) {
	this.display = true;
	this.action = action;
  }

}
