import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { MessageService } from 'primeng/api';
import { VacancyService } from '../core/services/vacancy.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Vacancy } from '../shared/models/vacancy.model';
import { VacancyRequest } from '../shared/models/vacancy-request.model';
import { City } from '../shared/models/city.model';
import { CityService } from '../core/services/city.service';

@Component({
  selector: 'app-vacancy-form',
  templateUrl: './vacancy-form.component.html',
  styleUrls: ['./vacancy-form.component.sass']
})

export class VacancyFormComponent implements OnInit {

  vacancyForm: FormGroup;
  display: Boolean = false;
  action: String;

  vacancy: Vacancy;
  cities: City[];
  selectedCity: City;

  @Output() loadVacancy = new EventEmitter();
  @Input()
  recruiterId: number;

  constructor(private messageService: MessageService,
    private formBuilder: FormBuilder,
    private vacancyService: VacancyService,
    private cityService: CityService ) {

    this.vacancy = this.defaultVacancy();

    this.vacancyForm = this.formBuilder.group({
      vacancyName:  ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      salary:       ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      city:         ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      description:  ['', [Validators.required, Validators.minLength(10), Validators.maxLength(50)]],
      offering:     ['', [Validators.required, Validators.minLength(30), Validators.maxLength(50)]],
      requirements: ['', [Validators.required, Validators.minLength(30), Validators.maxLength(50)]],
      bePlus:       ['', [Validators.required, Validators.minLength(30), Validators.maxLength(50)]]
    });


  }

  ngOnInit() {
    this.loadCities();
  }

  loadCities() {
    this.cityService.getAll()
      .subscribe((data: City[]) => this.cities = data);
  }


  defaultVacancy(): Vacancy {
    return {
      id: 0,
      name: '',
      description: '',
      offering: '',
      requirements: '',
      bePlus: '',
      isChecked: false,
      salary: 0,
      fullPartTime: '',
      createDate: new Date(),
      modDate: new Date(),
      city: null,
      recruiter: null,
      workArea: null
    };
  }

  showVacancyForm(action: String, vacancies = this.defaultVacancy()) {
    this.vacancy = vacancies;
    this.vacancyForm.reset();
    this.display = true;
    this.action = action;
    if (action === 'Update') {
      this.vacancyForm.setValue({
        vacancyName: this.vacancy.name,
        salary: this.vacancy.salary,
        city: this.vacancy.city,
        description: this.vacancy.description,
        offering: this.vacancy.offering,
        requirements: this.vacancy.requirements,
        bePlus: this.vacancy.bePlus

      });
    }
  }
}
