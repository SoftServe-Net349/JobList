import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { VacancyService } from '../core/services/vacancy.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Vacancy } from '../shared/models/vacancy.model';
import { City } from '../shared/models/city.model';
import { CityService } from '../core/services/city.service';
import { VacancyRequest } from '../shared/models/vacancy-request.model';
import { WorkArea } from '../shared/models/work-area.model';
import { WorkAreaService } from '../core/services/work-area.service';


@Component({
  selector: 'app-vacancy-form',
  templateUrl: './vacancy-form.component.html',
  styleUrls: ['./vacancy-form.component.sass']
})

export class VacancyFormComponent implements OnInit {

  vacancyForm: FormGroup;

  @Output() loadVacancy = new EventEmitter();

  @Input()
  recruiterId: number;

  display: Boolean = false;
  action: String;


  vacancy: Vacancy;

  cities: City[];
  selectedCity: City;

  workAreas: WorkArea[];
  selectedWorkArea: WorkArea;


  constructor(private formBuilder: FormBuilder,
    private vacancyService: VacancyService,
    private cityService: CityService,
    private workAreaService: WorkAreaService) {

    this.vacancy = this.defaultVacancy();

    this.vacancyForm = this.formBuilder.group({
      vacancyName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(200)]],
      salary: ['', [Validators.pattern('^[0-9 .]{1,30}$'), Validators.maxLength(15)]],
      city: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]],
      description: ['', [Validators.required, Validators.minLength(2)]],
      offering: ['', [Validators.required, Validators.minLength(2)]],
      requirements: ['', [Validators.required, Validators.minLength(2)]],
      bePlus: ['', [Validators.minLength(2)]],
      fullPartTime: ['', [Validators.minLength(2), Validators.maxLength(25)]],
      workArea: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(100)]]
    });
  }

  ngOnInit() {
    this.loadCities();
    this.loadWorkAreas();
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

  loadCities() {
    this.cityService.getAll()
      .subscribe((data: City[]) => this.cities = data);
  }

  loadWorkAreas(){
    this.workAreaService.getAll()
    .subscribe((data: WorkArea[]) => this.workAreas = data);
  }

  showVacancyForm(action: String, vacancy = this.defaultVacancy()) {
    this.vacancy = vacancy;
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
        bePlus: this.vacancy.bePlus,
        fullPartTime: this.vacancy.fullPartTime,
        workArea: this.vacancy.workArea
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
    const request : VacancyRequest = this.getRequest();
    this.vacancyService.update(this.vacancy.id, request)
      .subscribe(data => this.loadVacancy.emit());
  }

  createVacancy(){
    const request : VacancyRequest = this.getRequest();
    this.vacancyService.create(request)
      .subscribe(data => this.loadVacancy.emit());
  }

  getRequest(): VacancyRequest{
    return  {
      name: this.vacancyForm.get('vacancyName').value,
      description: this.vacancyForm.get('description').value,
      offering: this.vacancyForm.get('offering').value,
      requirements: this.vacancyForm.get('requirements').value,
      bePlus: this.vacancyForm.get('bePlus').value,
      isChecked: false,
      salary: this.vacancyForm.get('salary').value,
      fullPartTime: this.vacancyForm.get('fullPartTime').value,
      createDate: this.vacancy.createDate,
      cityId: this.selectedCity.id,
      recruiterId:this.recruiterId,
      workAreaId: this.selectedWorkArea.id
    };
  }
}

