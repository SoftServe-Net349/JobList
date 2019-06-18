import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormGroup, FormArray, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ConfirmationService } from 'primeng/api';
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
import { EducationPeriodRequest } from '../shared/models/education-period-request.model';
import { ExperienceRequest } from '../shared/models/experience-request.model';
import { controlNameBinding } from '@angular/forms/src/directives/reactive_directives/form_control_name';

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

  educationPeriods: EducationPeriod[];
  experiences: Experience[];

  selectedWorkArea: WorkArea;
  selectedCity: City;
  selectedLanguages: Language[];
  birthDate: Date;

  type: string;
  uploadedFile: File;
  dataString: string | ArrayBuffer;
  base64: string;
  array: EducationPeriod[] = [];
  arrayExperience: Experience[] = [];

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
    private experienceService: ExperienceService,
    private confirmationService: ConfirmationService) {
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
          // this.initEducation(),
        ])
      });

      this.FormExperience = this.formBuilder.group({
        FrontEnd: [''],
        companyName: [''],
        position: [''],
        itemsExperience: this.formBuilder.array([
          // this.initExperience(),
        ])
      });

    });

    this.employeeForm = this.defaultEmployeeForm();
    this.resumeForm = this.defaultResumeForm();
  }

  onUpload(event) {

    this.uploadedFile = event.files[0];
    const reader = new FileReader();

    reader.onload = () => {
      this.dataString = reader.result;
      this.base64 = this.dataString.toString().split(',')[1];
    };

    reader.readAsDataURL(this.uploadedFile);
    this.type = this.uploadedFile.type.toString().split('/')[1];

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
    this.array.push({
      id: 0,
      startDate: new Date(),
      finishDate: new Date(),
      resumeId: this.resume.id,
      school: null,
      faculty: null,
    });
    control.push(this.initEducation());
  }

  deleteEducation(i: number) {
    const control = <FormArray>this.FormEducation.controls['itemsEducation'];
    control.removeAt(i);
    this.array.splice(i, 1);
  }

  deleteExperience(i: number) {
    const control = <FormArray>this.FormExperience.controls['itemsExperience'];
    control.removeAt(i);
    this.array.splice(i, 1);
  }

  addExperience() {
    const control = <FormArray>this.FormExperience.controls['itemsExperience'];
    this.arrayExperience.push({
      id: 0,
      startDate: new Date(),
      finishDate: new Date(),
      resumeId: this.resume.id,
      position: 'ttrtr',
      companyName: 'rtete',
    });
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
      .subscribe((data: Resume) => {
        this.resume = data;
      });
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
      items: this.formBuilder.array([
        this.formBuilder.group({
          positionExp: '',
          companyName: ''
        })
      ])
    });

  }

  addItem(positionExp: string, companyName: string) {
    (<FormArray>this.resumeForm.controls['items']).push(
      this.formBuilder.group({
        positionExp: positionExp,
        companyName: companyName
      }));
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

  deleteConfirm(id: number) {
    this.confirmationService.confirm({
      message: 'Do you want to delete this record?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      accept: () => {
        this.educationPeriodsService.delete(id);
      }
    });
  }

  showResumeForm(action: string, resume = null) {
    debugger;
    this.resume = resume;
    this.resumeForm.reset();
    this.display = true;
    this.action = action;

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
      items: [{
        'positionExp': new FormControl(),
        'companyName': new FormControl()
      }]
    });

    this.resume.educationPeriods.forEach(ePeriod => {
      ePeriod.startDate = new Date(ePeriod.startDate);
    });
    this.resume.educationPeriods.forEach(ePeriod => {
      ePeriod.finishDate = new Date(ePeriod.finishDate);
    });

    this.resume.experiences.forEach(experiences => {
      experiences.startDate = new Date(experiences.startDate);
    });
    this.resume.experiences.forEach(experiences => {
      experiences.finishDate = new Date(experiences.finishDate);
    });

    this.resume.experiences.forEach(exp => {
      this.addItem(exp.position, exp.companyName);
    });

    (<FormArray>this.resumeForm.controls['items']).removeAt(0);

    this.selectedLanguages = this.languages;

  }


  getLanguages(): string {
    let languages = '';

    if (this.resume !== undefined) {
      this.resume.resumeLanguages.forEach(rl => {
        languages = rl.language.name + ', ' + languages;
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

    this.resume.educationPeriods.forEach(education => {
      const educationRequest: EducationPeriodRequest = {
        startDate: education.startDate,
        finishDate: education.finishDate,
        resumeId: education.resumeId,
        schoolId: education.school.id,
        facultyId: education.faculty.id
      };
      this.educationPeriodsService.update(education.id, educationRequest)
        .subscribe(data => this.loadResume.emit());
    });

    this.resume.experiences.forEach(experience => {
      const experiencesRequest: ExperienceRequest = {
        startDate: experience.startDate,
        finishDate: experience.finishDate,
        resumeId: experience.resumeId,
        position: experience.position,
        companyName: experience.companyName,
      };
      this.experienceService.update(experience.id, experiencesRequest)
        .subscribe(data => this.loadResume.emit());
    });
  }

  getRequestEmployee(): EmployeeUpdateRequest {
    return {
      firstName: this.employeeForm.get('firstName').value,
      lastName: this.employeeForm.get('lastName').value,
      phone: this.employeeForm.get('phone').value,
      photoData: this.base64,
      photoMimeType: this.type,
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
      position: this.resumeForm.get('position').value,
      introduction: this.resumeForm.get('keySkills').value,
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
    this.employee.photoData = this.base64;
    this.employee.photoMimeType = this.type;
    this.employee.city = this.employeeForm.get('city').value;
  }


  submitEmployeeForm() {
    this.updateInformation();
    this.UpdateEmployee();
    this.infoDialog = false;
  }

  submit() {
    this.array.forEach(element => {
      // this.schools.find(x => x.name == element.school);
      this.resume.educationPeriods.push(element);
    });
    this.updateResume();
    this.UpdateResume();
    this.display = false;

    const control = <FormArray>this.FormEducation.controls['itemsEducation'];
    let ind = 0;
    this.array.forEach(el => {
      control.removeAt(ind);
      ind++;
    });
    this.array = [];

    const controlExp = <FormArray>this.FormEducation.controls['itemsExperience'];
    let exp = 0;
    this.arrayExperience.forEach(el => {
      controlExp.removeAt(exp);
      exp++;
    });
    this.arrayExperience = [];
  }
}
