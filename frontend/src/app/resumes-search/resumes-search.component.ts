import { Component, OnInit, ViewChild } from '@angular/core';
import { Resume } from '../shared/models/resume.model';
import { ResumeService } from '../core/services/resume.service';
import { ResumessearchQuery } from '../shared/filterQueries/ResumessearchQuery';
import { Paginator } from 'primeng/primeng';
import { PaginationQuery } from '../shared/filterQueries/PaginationQuery';
import { Employee } from '../shared/models/employee.model';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { CompanyFiltersComponent } from '../company-filters/company-filters.component';

@Component({
  selector: 'app-resumes-search',
  templateUrl: './resumes-search.component.html',
  styleUrls: ['./resumes-search.component.sass']
})
export class ResumesSearchComponent implements OnInit {

  resumes: Resume[];
  employee: Employee;

  totalRecords: number;

  param: ResumessearchQuery;
  pagination: PaginationQuery;

  isButtonReset: boolean;

  @ViewChild('p') paginator: Paginator;

  @ViewChild(CompanyFiltersComponent) companyFilters: CompanyFiltersComponent;

  constructor(private resumeService: ResumeService,
              private _sanitizer: DomSanitizer) {


    this.resumes = [];
    this.param = this.getDefaultParam();

    this.pagination = this.getDefaultPaginationParam();
    this.totalRecords = 0;

    this.isButtonReset = false;
  }

  ngOnInit() {
    this.loadResumes();
  }

  getDefaultParam(): ResumessearchQuery {
    return {
      position: '',
      city: '',
      workArea: '',
      schools: [],
      faculties: [],
      startAge: 0,
      finishAge: 0,
      languages: []
    };
  }

  getDefaultPaginationParam(): PaginationQuery {
    return {
      pageSize: 4,
      pageNumber: 1
    };
  }

  getResumesByFilter(param: ResumessearchQuery) {
    this.param.workArea = param.workArea !== null ? param.workArea : this.param.workArea;
    this.param.position = param.position !== null ? param.position : this.param.position;
    this.param.city = param.city !== null ? param.city : this.param.city;
    this.param.schools = param.schools !== null ? param.schools : this.param.schools;
    this.param.faculties = param.faculties !== null ? param.faculties : this.param.faculties;
    this.param.startAge = param.startAge !== null ? param.startAge : this.param.startAge;
    this.param.finishAge = param.finishAge !== null ? param.finishAge : this.param.finishAge;
    this.param.languages = param.languages !== null ? param.languages : this.param.languages;

    this.isButtonReset = param.languages.length !== 0 || param.schools.length !== 0 ||
                         param.faculties.length !== 0 || param.workArea !== '';

    this.loadResumes();

    if (this.paginator.first !== 0) {
      this.paginator.changePage(0);
    }
  }

  sanitizeEmployeesImg(imageBase64): SafeUrl {
    if (this.employee !== undefined && this.employee.photoData !== undefined &&
        this.employee.photoData !== null && this.employee.photoData !== '') {

      return this._sanitizer.bypassSecurityTrustUrl(`data:image/${this.employee.photoMimeType};base64,` + imageBase64);

    } else {

      return '../../images/yourAvatarHere.png';

    }
  }

  resetWorkArea() {
    this.companyFilters.resetWorkArea();
    this.companyFilters.filter();
  }

  resetSchool(index: number) {
    const school = this.param.schools[index];

    this.companyFilters.resetSchool(school);
    this.companyFilters.filter();
  }

  resetFaculty(index: number) {
    const faculty = this.param.faculties[index];

    this.companyFilters.resetFaculty(faculty);
    this.companyFilters.filter();
  }

  resetLanguage(index: number) {
    const language = this.param.languages[index];

    this.companyFilters.resetLanguage(language);
    this.companyFilters.filter();
  }

  resetAll() {
    this.isButtonReset = false;
    this.companyFilters.resetAll();
  }

  paginate(event) {
    this.pagination = {
      pageNumber: ++event.page,
      pageSize: event.rows
    };

    this.loadResumes();
  }

  loadResumes() {
    this.resumeService.getByFilter(this.param, this.pagination)
      .subscribe((response) => {
        this.resumes = response.body;
        this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
      });
  }
}
