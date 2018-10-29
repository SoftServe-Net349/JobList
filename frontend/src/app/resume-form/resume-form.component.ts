
import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormArray, FormBuilder, Validators } from '@angular/forms';
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
import { ActivatedRoute, Params } from '@angular/router';
import { ResumeService } from '../core/services/resume.service';
import { EmployeeService } from '../core/services/employee.service';
import { ResumeRequest } from '../shared/models/resume-request.model';
import { EducationPeriodsService } from '../core/services/education-periods.service';
import { ExperienceService } from '../core/services/experience.service';
import { EducationPeriod } from '../shared/models/education-period.model';
import { Experience } from '../shared/models/experience.model';
import { EmployeeUpdateRequest } from '../shared/models/employee-update-request.model';



@Component({
  selector: 'app-resume-form',
  templateUrl: './resume-form.component.html',
  styleUrls: ['./resume-form.component.sass']
})

export class ResumeFormComponent implements OnInit {
  FormEducation: FormGroup;
  FormExperience: FormGroup;
  resumeForm: FormGroup;
  employeeForm: FormGroup;

  infoDialog = false;
  display = false;
  @Input() action = 'Create';

  @Output() loadResume = new EventEmitter();

  employee: Employee;
  resume: Resume;
  // role: Role;
  sex: string;
  workAreas: WorkArea[];
  languages: Language[];
  cities: City[];
  schools: School[];
  faculties: Faculty[];

  educationPeriods: EducationPeriod [];
  experience: Experience[];

  selectedWorkArea: WorkArea;
  selectedCity: City;
  selectedLanguages: Language[];
  birthDate: Date;

  constructor(private formBuilder: FormBuilder,
              private workAreaService: WorkAreaService,
              private cityService: CityService,
              private languageService: LanguageService,
              private schoolService: SchoolService,
              private facultyService: FacultyService,
              private activatedRoute: ActivatedRoute,
              private resumeService: ResumeService,
              private employeeService: EmployeeService,
              private educationPeriodsService: EducationPeriodsService,
              private experienceService: ExperienceService) {
  }

  ngOnInit() {
    this.loadWorkAreas();
    this.loadLanguages();
    this.loadCities();
    this.loadSchools();
    this.loadFaculties();
    this.activatedRoute.params.forEach((params: Params) => {
      const id = +params['id'];
      this.loadResumeById(id);


      this.FormEducation = this.formBuilder.group({
        FrontEnd: [''],
        itemsEducation: this.formBuilder.array([
          this.initEducation(),
        ])
      });

      this.FormExperience = this.formBuilder.group({
        FrontEnd: [''],
        companyName: [''],
        position: [''],
        itemsExperience: this.formBuilder.array([
          this.initExperience(),
        ])
      });

    });

    this.employeeForm = this.defaultEmployeeForm();
    this.resumeForm = this.defaultResumeForm();
  }

  initEducation() {
        return this.formBuilder.group({
        });
  }

  initExperience() {
        return this.formBuilder.group({
          companyName: ['', [Validators.minLength(2), Validators.maxLength(200)]],
          position: ['', [Validators.minLength(2), Validators.maxLength(200)]],
        });
  }

  addEducation() {
        const control = <FormArray>this.FormEducation.controls['itemsEducation'];
        control.push(this.initEducation());
  }

  addExperience() {
        const control = <FormArray>this.FormExperience.controls['itemsExperience'];
        control.push(this.initExperience());
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

  loadResumeById(id: number) {
    this.resumeService.getById(id)
    .subscribe((data: Resume) => this.resume = data);
  }


  defaultResumeForm(): FormGroup {
    return this.formBuilder.group({

      familyState: ['', [Validators.minLength(1), Validators.maxLength(20)]],
      softSkills: [''],
      keySkills: [''],
      courses: [''],
      position: [''],
      linkedIn: ['', [Validators.minLength(1), Validators.maxLength(200)]],
      gitHub: ['', [Validators.minLength(1), Validators.maxLength(200)]],
      facebook: ['', [Validators.minLength(1), Validators.maxLength(200)]],
      skype: ['', [Validators.minLength(1), Validators.maxLength(200)]],
      instagram: ['', [Validators.minLength(1), Validators.maxLength(200)]],
      workArea: ['', [Validators.required]],
      introduction: ['', [Validators.minLength(1), Validators.maxLength(300)]],
    });
  }

  defaultEmployeeForm(): FormGroup {
    return this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email, Validators.minLength(6), Validators.maxLength(254),
        Validators.pattern('^[A-Za-z0-9!#$%&\'*+\/=?^_`{|}~.-]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$')]],
      city: ['', [Validators.required]],
      birthDate: ['', [Validators.required]],
      phone: ['']
    });
  }

  showInfoForm(employee: Employee) {
    this.employee = employee;
    this.employeeForm.reset();
    this.infoDialog = true;

    this.employeeForm.setValue({
      firstName: this.employee.firstName,
      lastName: this.employee.lastName,
      email: this.employee.email,
      phone: this.employee.phone,
      city: this.employee.city,
      birthDate: new Date(this.employee.birthDate),
      // sex: this.sex,
    });
    this.selectedCity = this.employee.city;
  }

  showResumeForm(action: string,  resume = null) {
    this.resume = resume;
    this.resumeForm.reset();
    this.display = true;
    this.action = action;

    this.resumeForm.setValue({
      courses: '',
      introduction: '',
      instagram: '',
      familyState: '',
      softSkills: '',
      keySkills: '',
      facebook: '',
      skype: '',
      linkedIn: '',
      gitHub: '',
      workArea: '',
      position: '',
    });

    if (action === 'Update') {
      this.resumeForm.setValue({
        position: this.resume.position,
        courses: this.resume.courses,
        introduction: this.resume.introduction,
        familyState: this.resume.familyState,
        softSkills: this.resume.softSkills,
        keySkills: this.resume.keySkills,
        facebook: this.resume.facebook,
        skype: this.resume.skype,
        linkedIn: this.resume.linkedin,
        gitHub: this.resume.github,
        instagram: this.resume.instagram,
        workArea: this.resume.workArea,
      });
      this.selectedLanguages = this.languages;

    }
  }


  getLanguages(): string {
    let languages = '';

    if (this.resume !== undefined) {
      this.resume.resumeLanguages.forEach(rl => {
        languages =  rl.language.name + ', ' + languages;
      });
    }

    return languages.slice(0, languages.length - 2); // to delete the last ,
  }
  updateInformation() {
    const requestEmployee: EmployeeUpdateRequest = this.getRequestEmployee();
    this.employeeService.update(this.employee.id, requestEmployee)
      .subscribe(data => this.loadResume.emit());
  }

  updateResume() {
     const requestResume: ResumeRequest = this.getRequestResume();
     this.resumeService.update(this.resume.id, requestResume)
       .subscribe(data => this.loadResume.emit());
  }

  getRequestEmployee(): EmployeeUpdateRequest {
    return  {
      firstName: this.employeeForm.get('firstName').value,
      lastName: this.employeeForm.get('lastName').value,
      phone: this.employeeForm.get('phone').value,
      photoData: this.employee.photoData,
      photoMimeType: this.employee.photoMimeType,
      sex: this.employee.sex,
      birthDate: this.employeeForm.get('birthDate').value,
      email: this.employeeForm.get('email').value,
      cityId: this.selectedCity.id,
      roleId: this.employee.role.id,
    };
  }

  getRequestResume(): ResumeRequest {
    return {
      id: this.resume.id,
      linkedin: this.resumeForm.get('linkedIn').value,
      github: this.resumeForm.get('gitHub').value,
      facebook: this.resumeForm.get('facebook').value,
      skype: this.resumeForm.get('skype').value,
      instagram: this.resumeForm.get('instagram').value,
      familyState: this.resumeForm.get('familyState').value,
      softSkills: this.resumeForm.get('softSkills').value,
      keySkills: this.resumeForm.get('keySkills').value,
      courses: this.resumeForm.get('courses').value,
      createDate: this.resume.createDate,
      workAreaId: this.selectedWorkArea.id,
      position: this.resumeForm. get('position').value,
      introduction: this.resumeForm. get('keySkills').value,
    };
  }

  UpdateResume() {
    this.resume.position = this.resumeForm.get('position').value;
    this.resume.linkedin = this.resumeForm.get('linkedIn').value;
    this.resume.github = this.resumeForm.get('gitHub').value;
    this.resume.facebook = this.resumeForm.get('facebook').value;
    this.resume.skype = this.resumeForm.get('skype').value;
    this.resume.instagram = this.resumeForm.get('instagram').value;
    this.resume.familyState = this.resumeForm.get('familyState').value;
    this.resume.softSkills = this.resumeForm.get('softSkills').value;
    this.resume.keySkills = this.resumeForm.get('keySkills').value;
    this.resume.courses = this.resumeForm.get('courses').value;
    this.resume.workArea = this.resumeForm.get('workArea').value;
  }

  UpdateEmployee() {
    this.employee.firstName = this.employeeForm.get('firstName').value;
    this.employee.lastName = this.employeeForm.get('lastName').value;
    this.employee.phone = this.employeeForm.get('phone').value;
    this.employee.sex = this.employee.sex;
    this.employee.birthDate = this.employeeForm.get('birthDate').value;
    this.employee.email = this.employeeForm.get('email').value;
    this.employee.photoData = this.employee.photoData;
    this.employee.photoMimeType = this.employee.photoMimeType;
    this.employee.city = this.employeeForm.get('city').value;
  }

  submitEmployeeForm() {
    this.updateInformation();
    this.UpdateEmployee();
    this.infoDialog = false;
  }

  submit() {
    this.updateResume();
    this.UpdateResume();
    this.display = false;
  }
}
