import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Employee } from '../shared/models/employee.model';
import { WorkAreaService } from '../core/services/work-area.service';
import { CityService } from '../core/services/city.service';
import { LanguageService } from '../core/services/language.service';
import { SchoolService } from '../core/services/school.service';
import { FacultyService } from '../core/services/faculty.service';
import { WorkArea } from '../shared/models/work-area.model';
import { Language } from '../shared/models/language.model';
import { City } from '../shared/models/city.model';
import { School } from '../shared/models/school.model';
import { Faculty } from '../shared/models/faculty.model';
import { Resume } from '../shared/models/resume.model';

@Component({
  selector: 'app-resume-form',
  templateUrl: './resume-form.component.html',
  styleUrls: ['./resume-form.component.sass']
})
export class ResumeFormComponent implements OnInit {

  resumeForm: FormGroup;

  display: Boolean = false;
  action: String;

  employee: Employee;
  resume: Resume;

  workAreas: WorkArea[];
  languages: Language[];
  cities: City[];
  schools: School[];
  faculties: Faculty[];

  selectedWorkArea: WorkArea;
  selectedCity: City;
  selectedLanguages: Language[];
  birthDate: Date;
  selectedShool1: School;
  selectedFaculty1: Faculty;
  edStartDate1: Date;
  edFinishDate1: Date;
  expStartDate: Date;
  expFinishDate: Date;

  constructor(private formBuilder: FormBuilder,
              private workAreaService: WorkAreaService,
              private cityService: CityService,
              private languageService: LanguageService,
              private schoolService: SchoolService,
              private facultyService: FacultyService) {

  }

  ngOnInit() {
    this.loadWorkAreas();
    this.loadLanguages();
    this.loadCities();
    this.loadSchools();
    this.loadFaculties();

    this.resumeForm = this.defaultResumeForm();
  }

  loadWorkAreas() {
    this.workAreaService.getAll()
    .subscribe((data: WorkArea[]) => this.workAreas = data);
  }

  loadLanguages() {
    this.languageService.getAll()
    .subscribe((data: Language[]) => this.languages = data);
  }

  loadCities() {
    this.cityService.getAll()
    .subscribe((data: City[]) => this.cities = data);
  }

  loadSchools() {
    this.schoolService.getAll()
    .subscribe((data: School[]) => this.schools = data);
  }

  loadFaculties() {
    this.facultyService.getAll()
    .subscribe((data: Faculty[]) => this.faculties = data);
  }

  defaultResumeForm(): FormGroup {
    return this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email, Validators.minLength(5), Validators.maxLength(150)]],
      phone: [''],
      companyName: ['', [Validators.minLength(2), Validators.maxLength(200)]],
      position: ['', [Validators.minLength(2), Validators.maxLength(200)]],
      courses: [''],
      familyState: ['', [Validators.minLength(2), Validators.maxLength(20)]],
      softSkills: [''],
      keySkills: [''],
      linkedIn: ['', [Validators.minLength(2), Validators.maxLength(200)]],
      gitHub: ['', [Validators.minLength(2), Validators.maxLength(200)]],
      facebook: ['', [Validators.minLength(2), Validators.maxLength(200)]],
      skype: ['', [Validators.minLength(2), Validators.maxLength(200)]],
      workArea: ['', [Validators.required]],
      city: ['', [Validators.required]],
      birthDate: ['', [Validators.required]]
    });
  }

  showResumeForm(action: String, employee = null, resume = null) {
    this.employee = employee;
    this.resume = resume;
    this.resumeForm.reset();
    this.display = true;
    this.action = action;

    if (action === 'Update') {
      this.resumeForm.setValue({
        firstName: this.employee.firstName,
        lastName: this.employee.lastName,
        email: this.employee.email,
        phone: this.employee.phone,
        companyName: 'SoftServe',
        position: '.NET DEVELOPER',
        courses: this.resume.courses,
        familyState: this.resume.familyState,
        softSkills: this.resume.softSkills,
        keySkills: this.resume.keySkills,
        facebook: this.resume.facebook,
        skype: this.resume.skype,
        linkedIn: this.resume.linkedin,
        gitHub: this.resume.github,
        workArea: this.resume.workArea,
        city: this.employee.city,
        birthDate: ''
      });
      // this.selectedWorkArea = this.workAreas[1];
      // this.selectedCity = this.cities[1];
      this.birthDate = new Date();
      this.selectedShool1 = this.schools[1];
      this.selectedFaculty1 = this.faculties[1];
      this.edStartDate1 = new Date();
      this.edFinishDate1 = new Date();
      this.expStartDate = new Date();
      this.expFinishDate = new Date();
      this.selectedLanguages = this.languages;
    }
  }
}
