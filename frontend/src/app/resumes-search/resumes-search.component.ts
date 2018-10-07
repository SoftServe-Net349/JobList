import { Component, OnInit } from '@angular/core';
import { Resume } from '../shared/models/resume.model';
import { ResumeService } from '../core/services/resume.service';

@Component({
  selector: 'app-resumes-search',
  templateUrl: './resumes-search.component.html',
  styleUrls: ['./resumes-search.component.sass']
})
export class ResumesSearchComponent implements OnInit {

  resumes: Resume[];

  totalRecords: number = 0;

  pageSize: number = 1;
  pageNumber: number = 1;

  search: string = '';
  city: string = '';

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
