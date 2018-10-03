import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
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

  recruiterForm: FormGroup;

  @Output() loadRecruiters = new EventEmitter();

  @Input()
  companyId: number;

  display: Boolean = false;
  action: String;

  recruiter: Recruiter;
  uploadedFiles: any[] = [];


  constructor(private messageService: MessageService,
              private formBuilder: FormBuilder,
              private recruiterService: RecruiterService) {

    this.recruiter = this.defaultRecruiter();

    this.recruiterForm = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email, Validators.minLength(5), Validators.maxLength(150)]],
      phone: ['']
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
      company: null,
      roleId: 0,
      photoData: [],
      photoMimetype: ''
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
    this.recruiterForm.reset();
    this.display = true;
    this.action = action;
    if (action === 'Update') {
      this.recruiterForm.setValue({
        firstName: this.recruiter.firstName,
        lastName: this.recruiter.lastName,
        email: this.recruiter.email,
        phone: this.recruiter.phone
      });
    }
  }

  submit() {
    if (this.action === 'Create') {
      this.createRecruiter();
    }
    if (this.action === 'Update') {
      this.updateRecruiter();
    }
    this.display = false;
  }

  updateRecruiter() {
    const request: RecruiterRequest = {
      firstName: this.recruiterForm.get('firstName').value,
      lastName: this.recruiterForm.get('lastName').value,
      email: this.recruiterForm.get('email').value,
      phone: this.recruiterForm.get('phone').value,
      password: this.recruiter.password,
      companyId: this.companyId,
      roleId: this.recruiter.roleId,
      photoData: this.recruiter.photoData,
      photoMimetype: this.recruiter.photoMimetype
    };
    this.recruiterService.update(this.recruiter.id, request)
    .subscribe(data => this.loadRecruiters.emit());
  }

  createRecruiter() {
    const request: RecruiterRequest = {
      firstName: this.recruiterForm.get('firstName').value,
      lastName: this.recruiterForm.get('lastName').value,
      email: this.recruiterForm.get('email').value,
      phone: this.recruiterForm.get('phone').value,
      password: 'sddsdsdsdsd',
      companyId: this.companyId,
      roleId: 3,
      photoData: this.recruiter.photoData,
      photoMimetype: this.recruiter.photoMimetype

    };
    this.recruiterService.create(request)
    .subscribe(data => this.loadRecruiters.emit());
  }
}
