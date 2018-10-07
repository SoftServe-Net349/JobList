import { Component, OnInit } from '@angular/core';
import { Recruiter } from '../shared/models/recruiter.model';
import { ConfirmationService } from 'primeng/api';
import { RecruiterService } from '../core/services/recruiter.service';
import { ActivatedRoute, Params } from '@angular/router';
import { VacancyService } from '../core/services/vacancy.service';
import { Vacancy } from '../shared/models/vacancy.model';


@Component({
  selector: 'app-recruiter',
  templateUrl: './recruiter.component.html',
  styleUrls: ['./recruiter.component.sass']
})
export class RecruiterComponent implements OnInit {

  display: Boolean = false;
  action: String;
  vacancies: Vacancy[];

  recruiter: Recruiter;

  constructor(
    private confirmationService: ConfirmationService,
    private recruiterService: RecruiterService,
    private vacancyService: VacancyService,
    private activatedRoute: ActivatedRoute) {

    this.recruiter = this.defaultRecruiter();
    this.vacancies = [];
    }


  ngOnInit() {
    this.activatedRoute.params.forEach((params: Params) => {
      const id = +params['id'];
      this.loadRecruiterById(id);
      this.loadVacancies(id);
    });
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

  loadRecruiterById(id: number) {
    this.recruiterService.getById(id)
    .subscribe((data: Recruiter) => this.recruiter = data);
  }

  loadVacancies(id: number = this.recruiter.id) {
    this.vacancyService.getByRecruiterId(id)
    .subscribe((data: Vacancy[]) => this.vacancies = data);
  }

  deleteConfirm(id: number) {
    this.confirmationService.confirm({
        message: 'Do you want to delete this record?',
        header: 'Delete Confirmation',
        icon: 'pi pi-info-circle',
        accept: () => { this.vacancyService.delete(id).subscribe(data => this.loadVacancies()); 
      }
    });
  }
}
