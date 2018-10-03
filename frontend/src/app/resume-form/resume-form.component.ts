import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { User } from '../shared/models/user.model';

@Component({
  selector: 'app-resume-form',
  templateUrl: './resume-form.component.html',
  styleUrls: ['./resume-form.component.sass']
})
export class ResumeFormComponent implements OnInit {

  resumeForm: FormGroup;

  display: Boolean = false;
  action: String;

  user: User;

  showDialog() {
    this.display = true;
  }

  constructor(private formBuilder: FormBuilder) {

    this.user = this.defaultUser();

    this.resumeForm = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email, Validators.minLength(5), Validators.maxLength(150)]],
      lastNmae: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      workArea: ['', [Validators.required]],
      selectedCompanies: [''],
      phone: ['']
    });
  }

  ngOnInit() {
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

  showResumeForm(action: String, user = this.defaultUser()) {
    this.user = user;
    this.resumeForm.reset();
    this.display = true;
    this.action = action;
    // if (action === 'Update') {
    //   this.resumeForm.setValue({
    //     firstName: this.recruiter.firstName,
    //     lastName: this.recruiter.lastName,
    //     email: this.recruiter.email,
    //     phone: this.recruiter.phone
    //   });
    // }
  }
}
