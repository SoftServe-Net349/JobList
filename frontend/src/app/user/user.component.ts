import { Component, OnInit } from '@angular/core';
import { User } from '../shared/models/user.model';
import { Resume } from '../shared/models/resume.model';
import { UserService } from '../core/services/user.service';
import { ResumeService } from '../core/services/resume.service';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.sass']
})
export class UserComponent implements OnInit {

  user: User;
  resume: Resume;

  constructor(private userService: UserService,
              private resumeService: ResumeService,
              private activatedRoute: ActivatedRoute) {
    this.user = this.defaultUser();
    this.resume = this.defaultResume();
  }

  defaultUser(): User {
    return {
      id: 0,
      address: '',
      birthData: new Date(),
      city: null,
      email: '',
      favoriteVacancies: [],
      firstName: '',
      lastName: '',
      password: '',
      phone: '',
      photoData: [],
      photoMimeType: '',
      roleId: 0,
      sex: ''
    };
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

  ngOnInit() {
    this.activatedRoute.params.forEach((params: Params) => {
      const id = +params['id'];
      this.loadUserById(id);
      this.loadResumeById(id);
    });
  }

  loadUserById(id: number) {
    this.userService.getById(id)
    .subscribe((data: User) => this.user = data);
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
