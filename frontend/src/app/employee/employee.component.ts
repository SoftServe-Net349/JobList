import { Component, OnInit } from '@angular/core';
import { Employee } from '../shared/models/employee.model';
import { Resume } from '../shared/models/resume.model';
import { EmployeeService } from '../core/services/employee.service';
import { ResumeService } from '../core/services/resume.service';
import { ActivatedRoute, Params } from '@angular/router';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.sass']
})
export class EmployeeComponent implements OnInit {

  employee: Employee;
  resume: Resume;

  constructor(private employeeService: EmployeeService,
              private resumeService: ResumeService,
              private activatedRoute: ActivatedRoute) {

  }


  ngOnInit() {
    this.activatedRoute.params.forEach((params: Params) => {
      const id = +params['id'];
      this.loadEmployeeById(id);
      this.loadResumeById(id);
    });
  }

  loadEmployeeById(id: number) {
    this.employeeService.getById(id)
    .subscribe((data: Employee) => this.employee = data);
  }

  loadResumeById(id: number) {
    this.resumeService.getById(id)
    .subscribe((data: Resume) => this.resume = data);
  }

  getLanguages(): string {
    let languages = '';

    if (this.resume !== undefined) {
      this.resume.resumeLanguages.forEach(rl => {
        languages =  rl.language.name + ', ' + languages;
      });
    }

    return languages.slice(0, languages.length - 2); // to delete the last ,
  }

}
