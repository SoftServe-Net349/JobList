import { Component, OnInit, ViewChild } from '@angular/core';
import { Resume } from '../shared/models/resume.model';
import { ResumeService } from '../core/services/resume.service';
import { ResumessearchQuery } from '../shared/filterQueries/ResumessearchQuery';
import { Paginator } from 'primeng/primeng';

@Component({
  selector: 'app-resumes-search',
  templateUrl: './resumes-search.component.html',
  styleUrls: ['./resumes-search.component.sass']
})
export class ResumesSearchComponent implements OnInit {

  resumes: Resume[];

  totalRecords = 0;

  pageSize = 4;
  pageNumber = 1;

  search = '';
  city = '';

  param: ResumessearchQuery;

  @ViewChild('p') paginator: Paginator;

  constructor(private resumeService: ResumeService) {
    this.resumes = [];
    this.param = this.getDefaultParam();
  }

  ngOnInit() {
    this.loadResumes();
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

    console.log('Languages: ' + this.param.languages);
    this.loadResumes();

    // this.paginator.changePage(0);
  }

  paginate(event) {
    this.pageNumber = event.page + 1;
    this.pageSize = event.rows;

    this.loadResumes();
  }

  loadResumes() {
    this.resumeService.getByFilter(this.param, this.pageSize, this.pageNumber)
      .subscribe((response) => {
        this.resumes = response.body;
        this.totalRecords = JSON.parse(response.headers.get('X-Pagination')).TotalRecords;
      });
  }
}
