import { Component, OnInit, ViewChild } from '@angular/core';
import { Resume } from '../shared/models/resume.model';
import { ResumeService } from '../core/services/resume.service';
import { ResumessearchQuery } from '../shared/filterQueries/ResumessearchQuery';
import { Paginator } from 'primeng/primeng';
import { PaginationQuery } from '../shared/filterQueries/PaginationQuery';

@Component({
  selector: 'app-resumes-search',
  templateUrl: './resumes-search.component.html',
  styleUrls: ['./resumes-search.component.sass']
})
export class ResumesSearchComponent implements OnInit {

  resumes: Resume[];

  totalRecords: number;

  search: string;
  city: string;

  param: ResumessearchQuery;
  pagination: PaginationQuery;

  @ViewChild('p') paginator: Paginator;

  constructor(private resumeService: ResumeService) {
    this.totalRecords = 0;

    this.search = '';
    this.city = '';

    this.resumes = [];
    this.param = this.getDefaultParam();
    this.pagination = this.getDefaultPaginationParam();
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
    this.param.position = param.position !== null ? param.position : this.param.position;
    this.param.city = param.city !== null ? param.city : this.param.city;
    this.param.workArea = param.workArea !== null ? param.workArea : this.param.workArea;
    this.param.schools = param.schools !== null ? param.schools : this.param.schools;
    this.param.faculties = param.faculties !== null ? param.faculties : this.param.faculties;
    this.param.startAge = param.startAge !== null ? param.startAge : this.param.startAge;
    this.param.finishAge = param.finishAge !== null ? param.finishAge : this.param.finishAge;
    this.param.languages = param.languages !== null ? param.languages : this.param.languages;

    this.loadResumes();

    if (this.paginator.first !== 0) {
      this.paginator.changePage(0);
    }
  }

  paginate(event) {
    this.pagination.pageNumber = event.page + 1;
    this.pagination.pageSize = event.rows;

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
