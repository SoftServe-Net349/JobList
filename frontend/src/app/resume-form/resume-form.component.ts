import { Component, OnInit } from '@angular/core';
import {SelectItem} from 'primeng/api';

@Component({
  selector: 'app-resume-form',
  templateUrl: './resume-form.component.html',
  styleUrls: ['./resume-form.component.sass']
})
export class ResumeFormComponent implements OnInit {

  title = 'JobList';
  maritalstatus: SelectItem[];
  edschool: SelectItem[];
  edfaculty: SelectItem[];
  languagelevel: SelectItem[];
  selectedStatus: string;

  display: Boolean = false;
  showDialog() {
      this.display = true;
  }

  constructor() {
    this.maritalstatus = [
      {label: 'Unmarried', value: 'Unmarried'},
      {label: 'Married', value: 'Married'},
      {label: 'Divorced', value: 'Divorced'},
    ];
    this.edschool = [
      {label: 'LNU', value: 'LNU'},
      {label: 'LPNU', value: 'LPNU'},
      {label: 'UKU', value: 'UKU'},
    ];
    this.edfaculty = [
      {label: 'IKNI', value: 'IKNI'},
      {label: 'IKTA', value: 'IKTA'},
      {label: 'ITRE', value: 'ITRE'},
    ];
    this.languagelevel = [
      {label: 'A1', value: 'A1'},
      {label: 'A2', value: 'A2'},
      {label: 'B1', value: 'B1'},
      {label: 'B2', value: 'B2'},
      {label: 'C1', value: 'C1'},
      {label: 'C2', value: 'C2'},
    ];
    }

  ngOnInit() {
  }

}
