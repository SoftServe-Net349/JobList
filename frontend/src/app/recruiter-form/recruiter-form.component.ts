import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { MessageService } from 'primeng/api';
import { Recruiter } from '../shared/models/recruiter.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { RecruiterService } from '../core/services/recruiter.service';
import { RecruiterRequest } from '../shared/models/recruiter-request.model';
import { RecruiterUpdateRequest } from '../shared/models/recruiter-update-request.model';

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
  errorMessage: string;

  recruiter: Recruiter;

  type: string;
  uploadedFiles: any[] = [];
  dataString: string|ArrayBuffer;
  base64: string;

  constructor(private messageService: MessageService,
              private formBuilder: FormBuilder,
              private recruiterService: RecruiterService) {

    this.recruiterForm = this.formBuilder.group({
      firstName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.minLength(2), Validators.maxLength(50)]],
      email: ['', [Validators.required, Validators.email, Validators.minLength(5), Validators.maxLength(150)]],
      phone: ['']
    });

  }

  ngOnInit() {
  }


  onUpload(event) {
    for (const file of event.files) {
    this.uploadedFiles.push(file);
     const reader = new FileReader();
     reader.onload = () => {
     this.dataString = reader.result;
     this.base64 = this.dataString.toString().split(',')[1];
    };
    reader.readAsDataURL(file);
    this.type = file.type.toString().split('/')[1];

   }
  }

  showRecruiterForm(action: String, recruiter = null) {
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

      this.type = this.recruiter.photoMimetype;
      // this.base64 = this.recruiter.photoData;
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
    const request: RecruiterUpdateRequest = {
      firstName: this.recruiterForm.get('firstName').value,
      lastName: this.recruiterForm.get('lastName').value,
      email: this.recruiterForm.get('email').value,
      phone: this.recruiterForm.get('phone').value,
      companyId: this.companyId,
      roleId: this.recruiter.role.id,
      photoData: [],
      photoMimetype: this.type
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
      password: '12345678',
      companyId: this.companyId,
      roleId: 4,
      photoData: [],
      photoMimetype: this.type

    };
    this.recruiterService.register(request)
    .subscribe((data: Recruiter) => {
      this.errorMessage = '';
      this.loadRecruiters.emit(); },
    error => { this.errorMessage = error.error; });
  }
}
