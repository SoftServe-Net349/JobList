import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { ResumeService } from '../core/services/resume.service';
import { Resume } from '../shared/models/resume.model';

@Component({
  selector: 'app-resume-details',
  templateUrl: './resume-details.component.html',
  styleUrls: ['./resume-details.component.sass']
})
export class ResumeDetailsComponent implements OnInit {

  display: Boolean = false;

  resume: Resume;

  showDialog() {
      this.display = true;
  }

  constructor(private activatedRoute: ActivatedRoute,
              private resumeService: ResumeService) {
                this.resume = this.defaultResume();
               }

  ngOnInit() {
    this.activatedRoute.params.forEach((params: Params) => {
      const id = +params['id'];
      this.loadResumeById(id);
    });
  }

  defaultResume(): Resume {
    return {
      id: 0,
      courses: '',
      createDate: new Date(),
      educationPeriods: [],
      experiences: [],
      facebook: '',
      familyState: '',
      github: '',
      instagram: '',
      keySkills: '',
      linkedin: '',
      modDate: new Date(),
      resumeLanguages: [],
      skype: '',
      softSkills: '',
      user: null,
      workArea: null
    };
  }

  loadResumeById(id: number) {
    this.resumeService.getById(id)
    .subscribe((data: Resume) => this.resume = data);
  }

  getLanguages(): string {
    let languages = '';
    this.resume.resumeLanguages.forEach(rl => {
      languages =  rl.language.name + ', ' + languages;
    });
    return languages.slice(0, languages.length - 2); // to delete the last ,
  }
}
