
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { MessageService } from 'primeng/api';

import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Vacancy } from '../shared/models/vacancy.model';
import { VacancyService } from '../core/services/vacancy.service';
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

  @Output() loadVacancies = new EventEmitter();

  display: Boolean = false;
  action: String;

  vacancy: Vacancy;
  cities: City[];
  sekectedCity: City;

  constructor(private messageService: MessageService,
    private formBuilder: FormBuilder,
    private recruiterService: VacancyService,
    private cityService: CityService){
  }


  ngOnInit() {
    this.loadCities();
  }


  loadCities(){
    this.cityService.getAll()
      .subscribe((data: City[]) => this.cities = data);
  }

  
  defaultVacancy(): Vacancy{
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
      createDate: null,
      modDate: null,
      city: null,
      recruiter: null,
      workArea: null
    };
  }

  showVacancyForm(action: String, vacancy = this.defaultVacancy()) {
    this.vacancy = vacancy;
    this.display = true;
    this.action = action;

    if(action === 'Update'){
      this.vacancyForm.setValue({
        name: this.vacancy.name,
        salary: this.vacancy.description,
        description: this.vacancy.description,
        offering: this.vacancy.offering,
        requirements: this.vacancy.requirements,
        bePlus: this.vacancy.bePlus
      });
    }
  }

  submit() {
    if (this.action === 'Create') {
      this.createVacancy();
    }
    if (this.action === 'Update') {
      this.updateVacancy();
    }
    this.display = false;
  }

  updateVacancy() {
    const request: VacancyRequest = {
      name: this.vacancyForm.get('name').value,
      salary: this.vacancyForm.get('salary').value,
      description: this.vacancyForm.get('description').value,
      offering: this.vacancyForm.get('offering').value,
      requirements: this.vacancyForm.get('requirements').value,
      bePlus: this.vacancyForm.get('bePlus').value,
      isChecked: false,
      fullPartTime: this.vacancy.fullPartTime,
      createDate: this.vacancy.createDate,
      modDate: this.vacancy.modDate,
      city: this.vacancy.city,
      recruiter: this.vacancy.recruiter,
      workArea: this.vacancy.workArea
    };
    this.recruiterService.update(this.vacancy.id, request)
    .subscribe(data => this.loadVacancies.emit());
  }


  createVacancy(){
    const request: VacancyRequest = {
      name: this.vacancyForm.get('name').value,
      salary: this.vacancyForm.get('salary').value,
      description: this.vacancyForm.get('description').value,
      offering: this.vacancyForm.get('offering').value,
      requirements: this.vacancyForm.get('requirements').value,
      bePlus: this.vacancyForm.get('bePlus').value,
      isChecked: false,
      fullPartTime: this.vacancy.fullPartTime,
      createDate: this.vacancy.createDate,
      modDate: this.vacancy.modDate,
      city: this.vacancy.city,
      recruiter: this.vacancy.recruiter,
      workArea: this.vacancy.workArea
    };
    this.recruiterService.create(request)
    .subscribe(data => this.loadVacancies.emit());
  }
}
