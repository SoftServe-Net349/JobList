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
  isSubmited:boolean = true;

  constructor(private resumeService:ResumeService) {
    this.resumes = [];
   }

  ngOnInit() {
    //if(isSubmited)
      this.loadResumes();
  }

  loadResumes(){
    this.resumeService.getAll()
    .subscribe((data:Resume[])=>this.resumes = data);
  }
}
