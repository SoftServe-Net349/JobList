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

  constructor(private userService: UserService,
              private activatedRoute: ActivatedRoute) {
    this.user = this.defaultUser();
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
      resumes: null,
      roleId: 0,
      sex: ''
    };
  }

  ngOnInit() {
    this.activatedRoute.params.forEach((params: Params) => {
      const id = +params['id'];
      this.loadUserById(id);
    });
  }

  loadUserById(id: number) {
    this.userService.getById(id)
    .subscribe((data: User) => this.user = data);
  }

  getLanguages(): string {
    let languages = '';
    if (this.user.resumes !== null) {
      this.user.resumes.resumeLanguages.forEach(rl => {
        languages = languages + ' ' + rl.language.name;
      });
    }
    return languages;
  }
}
