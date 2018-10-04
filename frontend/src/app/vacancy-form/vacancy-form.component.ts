
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { MessageService } from 'primeng/api';

import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-vacancy-form',
  templateUrl: './vacancy-form.component.html',
  styleUrls: ['./vacancy-form.component.sass']
})

export class VacancyFormComponent implements OnInit {

  display: Boolean = false;
  action: String;

  vacancyForm: FormGroup;

  @Output() loadRecruiters = new EventEmitter();

  ngOnInit() {
  }

  showVacancyForm(action: String) {
    this.display = true;
    this.action = action;
    }

}

class City {
  name: string;
  code: string;
}
