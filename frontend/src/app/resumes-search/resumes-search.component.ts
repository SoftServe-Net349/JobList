import { Component, OnInit } from '@angular/core';
import { Resume } from '../shared/models/resume.model';
import { ResumeService } from '../core/services/resume.service';
import { ResumessearchQuery } from '../shared/filterQueries/ResumessearchQuery';

@Component({
  selector: 'app-resumes-search',
  templateUrl: './resumes-search.component.html',
  styleUrls: ['./resumes-search.component.sass']
})
export class ResumesSearchComponent implements OnInit {

  resumes: Resume[];

  totalRecords = 0;

  pageSize = 1;
  pageNumber = 1;

  search = '';
  city = '';

  param: ResumessearchQuery;

  constructor(private resumeService: ResumeService) {
    this.resumes = [];
  }

  ngOnInit() {
    this.loadResumes(this.pageSize, this.pageNumber);
  }

  getResumesBySearchString(param: { search: string, city: string }) {
    this.search = param.search;
    this.city = param.city;

    if (param.search === '' && param.city === '') {
      this.loadResumes(this.pageSize, this.pageNumber);
    } else {
      this.resumeService.getBySearchString(this.search, this.city, this.pageSize, this.pageNumber)
        .subscribe((response) => {
          this.resumes = response.body;
          this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
        });
    }
  }

  getDefaultParam(): ResumessearchQuery {
    return {
      name: '',
      city: '',
      workArea: '',
      schools: [],
      faculties: [],
      age: 0,
      languages: []
    };
  }

  getResumesByFilter(param: ResumessearchQuery) {
    this.param.name = param.name !== null ? param.name : this.param.name;
    this.param.city = param.city !== null ? param.city : this.param.city;
    this.param.workArea = param.workArea !== null ? param.workArea : this.param.workArea;
    this.param.schools = param.schools !== null ? param.schools : this.param.schools;
    this.param.faculties = param.faculties !== null ? param.faculties : this.param.faculties;
    this.param.age = param.age !== null ? param.age : this.param.age;
    this.param.languages = param.languages !== null ? param.languages : this.param.languages;

    if (param === this.getDefaultParam()) {
      this.loadResumes(this.pageSize, this.pageNumber);
    } else {
      this.resumeService.getByFilter(this.param, this.pageSize, this.pageNumber)
        .subscribe((response) => {
          this.resumes = response.body;
          this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
        });
    }
  }

  paginate(event) {
    this.pageNumber = event.page + 1;

    if (this.search === '' && this.city === '') {
      this.loadResumes(event.rows, this.pageNumber);
    } else {
      this.resumeService.getBySearchString(this.search, this.city, event.rows, this.pageNumber)
        .subscribe((response) => {
          this.resumes = response.body;
        });
    }
  }

  loadResumes(pageSize: number, pageNumber: number) {
    this.resumeService.getFullResponse(pageSize, pageNumber)
      .subscribe((response) => {
        this.resumes = response.body;
        this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
      });
  }
}
