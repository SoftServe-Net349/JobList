import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { MessageService } from 'primeng/api';
import { VacancyService } from '../core/services/vacancy.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Vacancy } from '../shared/models/vacancy.model';
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

  vacancies: Vacancy;
  cities: City[];
  @Output() loadVacancy = new EventEmitter();
  @Input()
  recruiterId: number;

  constructor(private messageService: MessageService,
    private formBuilder: FormBuilder,
    private vacancyService: VacancyService,
    private cityService: CityService ) {

    this.vacancies = this.defaultVacancy();

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

  defaultVacancy(): Vacancy {
    return {
      id: 0,
      name: '',
      description: '',
      offering: '',
      requirements: '',
      bePlus: '',
      isChecked: '',
      salary: 0,
      fullPartTime: '',
      createDate: new Date(),
      modDate: new Date(),
      city: null,
      recruiter: null,
      workArea: null
    };
  }

  loadCities() {
    this.cityService.getAll()
    .subscribe((data: City[]) => this.cities = data);
  }

  showVacancyForm(action: String, vacancies = this.defaultVacancy()) {
    this.vacancies = vacancies;
    this.vacancyForm.reset();
    this.display = true;
    this.action = action;
    if (action === 'Update') {
      this.vacancyForm.setValue({
        vacancyName: this.vacancies.name,
        salary: this.vacancies.salary,
        city: this.vacancies.city,
        description: this.vacancies.description,
        offering: this.vacancies.offering,
        requirements: this.vacancies.requirements,
        bePlus: this.vacancies.bePlus

      });
    } }}

