import { Component, OnInit, Output, EventEmitter, OnInit } from '@angular/core';
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
import { EmployeeRequest } from '../shared/models/employee-request.model';
import { ResumeRequest } from '../shared/models/resume-request.model';
import { Role} from '../shared/models/role.model';
import { EducationPeriodsService } from '../core/services/education-periods.service';
import { ExperienceService } from '../core/services/experience.service';
import { EducationPeriod } from '../shared/models/education-period.model';
import { Experience } from '../shared/models/experience.model';


@Component({
  selector: 'app-resume-form',
  templateUrl: './resume-form.component.html',
  styleUrls: ['./resume-form.component.sass']
})
export class ResumeFormComponent implements OnInit {
  FormEducation: FormGroup;
  FormExperience: FormGroup;
  resumeForm: FormGroup;

  display: Boolean = false;
  @Input() action: string;

  @Output() loadResume = new EventEmitter();
  employee: Employee;
  resume: Resume;
  role: Role;

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
              private facultyService: FacultyService,
              private activatedRoute: ActivatedRoute,
              private resumeService: ResumeService,
              private employeeService: EmployeeService,
              private educationPeriodsService: EducationPeriodsService,
              private experienceService: ExperienceService) {
                this.defaultFormExperience();
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
      this.loadEducationPeriod(id);
      // this.loadExperience(id);
    });

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

  loadResumeById(id: number) {
    this.resumeService.getById(id)
    .subscribe((data: Resume) => this.resume = data);
  }

  loadEducationPeriod(id: number) {
    this.educationPeriodsService.getEducationPeriodByResumeId(id)
    .subscribe((data: EducationPeriod[]) => this.educationPeriods = data
  );
  }

  loadExperience(id: number) {
    this.experienceService.getExperienceByResumeId(id)
    .subscribe((data: Experience[]) => this.experience = data);
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
  defaultResumeForm(): FormGroup {
    return this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.minLength(1), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email, Validators.minLength(6), Validators.maxLength(254),
        Validators.pattern('^[a-z0-9!#$%&\'*+\/=?^_`{|}~.-]+(\\.[_A-Za-z0-9-]+)*@[A-Za-z0-9-]+(\\.[A-Za-z0-9]+)*(\\.[A-Za-z]{2,})$')]],
      phone: [''],
      companyName: ['', [Validators.minLength(1), Validators.maxLength(200)]],
      position: ['', [Validators.minLength(1), Validators.maxLength(100)]],
      familyState: ['', [Validators.minLength(1), Validators.maxLength(20)]],
      softSkills: [''],
      keySkills: [''],
      courses: [''],
      linkedIn: ['', [Validators.minLength(1), Validators.maxLength(200)]],
      gitHub: ['', [Validators.minLength(1), Validators.maxLength(200)]],
      facebook: ['', [Validators.minLength(1), Validators.maxLength(200)]],
      skype: ['', [Validators.minLength(1), Validators.maxLength(200)]],
      workArea: ['', [Validators.required]],
      city: ['', [Validators.required]],
      birthDate: ['', [Validators.required]],
      introduction: ['', [Validators.minLength(1), Validators.maxLength(300)]],
    });
  }
  defaultFormExperience(): FormGroup {
    return this.formBuilder.group({
      companyName: ['', [Validators.minLength(2), Validators.maxLength(200)]],
      position: ['', [Validators.minLength(2), Validators.maxLength(200)]]
    });
  }

  showResumeForm(action: string, employee = null, resume = null) {
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
        companyName: this.resume.experiences,
        position: this.resume.experiences,
        courses: this.resume.courses,
        introduction: this.resume.introduction,
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
      this.birthDate = new Date(this.employee.birthDate);
      this.selectedShool1 = this.schools[1];
      this.selectedFaculty1 = this.faculties[1];
      this.edStartDate1 = new Date();
      this.edFinishDate1 = new Date();
      this.expStartDate = new Date();
      this.expFinishDate = new Date();
      this.selectedLanguages = this.languages;
    }
  }
  updateResume() {
    const requestEmployee: EmployeeRequest = this.getRequestEmployee();
    this.employeeService.update(this.employee.id, requestEmployee)
      .subscribe(data => this.loadResume.emit());

     const requestResume: ResumeRequest = this.getRequestResume();
     this.resumeService.update(this.employee.id, requestResume)
       .subscribe(data => this.loadResume.emit());
  }
getRequestEmployee(): EmployeeRequest {
    return  {
      firstName: this.resumeForm.get('firstName').value,
      lastName: this.resumeForm.get('lastName').value,
      phone: this.resumeForm.get('phone').value,
      photoData: this.employee.photoData,
      photoMimeType: this.employee.photoMimeType,
      sex: this.employee.sex,
      birthDate: this.employee.birthDate,
      email: this.resumeForm.get('email').value,
      password: 'qwerty',
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
      instagram: this.resume.instagram,
      familyState: this.resumeForm.get('familyState').value,
      softSkills: this.resumeForm.get('softSkills').value,
      keySkills: this.resumeForm.get('keySkills').value,
      courses: this.resumeForm.get('courses').value,
      createDate: this.resume.createDate,
      workAreaId: this.selectedWorkArea.id,
      position: this.resumeForm. get('keySkills').value,
      introduction: this.resumeForm. get('keySkills').value,
    };
  }
Update() {
    this.employee.firstName = this.resumeForm.get('firstName').value;
    this.employee.lastName = this.resumeForm.get('lastName').value;
    this.employee.phone = this.resumeForm.get('phone').value;
    this.employee.photoData = this.employee.photoData;
    this.employee.photoMimeType = this.employee.photoMimeType;
    this.employee.sex = this.employee.sex;
    this.employee.birthDate = this.employee.birthDate;
    this.employee.email = this.resumeForm.get('email').value;
    this.resume.linkedin = this.resumeForm.get('linkedIn').value;
    this.resume.github = this.resumeForm.get('gitHub').value;
    this.resume.facebook = this.resumeForm.get('facebook').value;
    this.resume.skype = this.resumeForm.get('skype').value;
    this.resume.instagram = this.resume.instagram;
    this.resume.familyState = this.resumeForm.get('familyState').value;
    this.resume.softSkills = this.resumeForm.get('softSkills').value;
    this.resume.keySkills = this.resumeForm.get('keySkills').value;
    this.resume.courses = this.resumeForm.get('courses').value;
  }
submit() {
  this.updateResume();
  this.Update();
  this.display = false;
  }
}
