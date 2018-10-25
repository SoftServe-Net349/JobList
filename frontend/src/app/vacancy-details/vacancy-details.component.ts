import { Component, OnInit } from '@angular/core';
import { Vacancy } from '../shared/models/vacancy.model';
import { ActivatedRoute, Params } from '@angular/router';
import { VacancyService } from '../core/services/vacancy.service';

@Component({
  selector: 'app-vacancy-details',
  templateUrl: './vacancy-details.component.html',
  styleUrls: ['./vacancy-details.component.sass']
})
export class VacancyDetailsComponent implements OnInit {

  vacancy: Vacancy;
  display: Boolean = false;

  constructor(private activatedRoute: ActivatedRoute,
              private vacancyService: VacancyService) {
  }

  ngOnInit() {
    this.activatedRoute.params.forEach((params: Params) => {
      const id = +params['id'];
      this.loadVacancyById(id);
    });
  }

  loadVacancyById(id: number = this.vacancy.id) {
    this.vacancyService.getById(id)
    .subscribe((data: Vacancy) => this.vacancy = data);
  }

  showDialog() {
    this.display = true;
  }

}
