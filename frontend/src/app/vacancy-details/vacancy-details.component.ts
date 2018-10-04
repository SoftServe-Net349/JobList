import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-vacancy-details',
  templateUrl: './vacancy-details.component.html',
  styleUrls: ['./vacancy-details.component.sass']
})
export class VacancyDetailsComponent implements OnInit {

  display: Boolean = false;

    showDialog() {
        this.display = true;
    }

  constructor() { }

  ngOnInit() {
  }

}
