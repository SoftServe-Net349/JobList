import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Recruiter } from '../shared/models/recruiter.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RecruiterService } from '../core/services/recruiter.service';
import { RecruiterRequest } from '../shared/models/recruiter-request.model';

@Component({
  selector: 'app-recruiter-form',
  templateUrl: './recruiter-form.component.html',
  styleUrls: ['./recruiter-form.component.sass']
})
export class RecruiterFormComponent implements OnInit {

  myForm: FormGroup;

  @Output() loadRecruiters = new EventEmitter<boolean>();

  display: Boolean = false;
  action: String;

  recruiter: Recruiter;
  confirmPassword: string;
  uploadedFiles: any[] = [];

  constructor(private messageService: MessageService,
  private formBuilder: FormBuilder,
  private recruiterService: RecruiterService) {
    this.recruiter = this.defaultRecruiter();
    this.myForm = formBuilder.group({
      'firstName': ['', [Validators.required]],
      'lastName': ['', [Validators.required]],
      'email': ['', [Validators.required]],
      'phone': ['', [Validators.required]],
      'password': ['', [Validators.required]],
      'confirmPassword': ['', [Validators.required]]
    });
  }

  ngOnInit() {
  }

  defaultRecruiter(): Recruiter {
    return {
      id: 0,
      firstName: '',
      lastName: '',
      phone: '',
      email: '',
      password: '',
      company: {
        id: 0, name: '',
        bossName: '',
        fullDescription: '',
        shortDescription: '',
        address: '',
        phone: '',
        logoData: [],
        logoMimetype: '',
        site: '',
        email: '',
        password: '',
        role: {id: 1, name: ''},
        recruiters: []
      },
      role: {id: 1, name: ''}
    };
  }

  onUpload(event) {
    for (const file of event.files) {
      this.uploadedFiles.push(file);
    }

    this.messageService.add({severity: 'info', summary: 'File Uploaded', detail: ''});
  }

  showRecruiterForm(action: String, recruiter = this.defaultRecruiter()) {
    this.recruiter = recruiter;
    this.myForm.reset();
    this.display = true;
    this.action = action;
  }

  submit() {
    if (this.action = 'Create') {
      // this.createRecruiter();
    }
    if (this.action = 'Update') {
      // this.updateRecruiter();
    }
    this.display = false;
    this.loadRecruiters.emit();
  }

  updateRecruiter() {
    const request: RecruiterRequest = {
      firstName: this.myForm.get('firstName').value,
      lastName: this.myForm.get('lastName').value,
      email: this.myForm.get('email').value,
      phone: this.myForm.get('phone').value,
      password: this.myForm.get('password').value
    };
    this.recruiterService.update(this.recruiter.id, request);
  }

  createRecruiter() {
    // const request: Recruiter = {
    //   firstName: this.myForm.get('firstName').value,
    //   lastName: this.myForm.get('lastName').value,
    //   email: this.myForm.get('email').value,
    //   phone: this.myForm.get('phone').value,
    //   password: this.myForm.get('password').value
    // };

  }
}
