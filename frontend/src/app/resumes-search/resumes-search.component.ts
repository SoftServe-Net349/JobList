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

  constructor(private resumeService: ResumeService) {
    this.resumes = [];
   }

  ngOnInit() {
      this.loadResumes();
  }

  loadResumes() {
    this.resumeService.getAll()
      .subscribe((data: Resume[]) => this.resumes = data);
  }

  getResumesBySearchString(param: {search: string, city: string}) {
    if (param.search === '' && param.city === '') {
      this.loadResumes();
    } else {
      this.resumeService.getBySearchString(param.search, param.city)
      .subscribe((data: Resume[]) => this.resumes = data);
    }
  }
}
