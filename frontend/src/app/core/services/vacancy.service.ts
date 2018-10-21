import { Injectable } from '@angular/core';
import { Vacancy } from '../../shared/models/vacancy.model';
import { Observable } from 'rxjs';
import { VacancyRequest } from '../../shared/models/vacancy-request.model';
import { ApiService } from './api.service';
import { HttpParams, HttpResponse } from '@angular/common/http';
import { JobSearchQuery } from '../../shared/filterQueries/JobsearchQuery';

@Injectable()
export class VacancyService {
  private ctrlUrl = 'vacancies';

  constructor(private apiService: ApiService) {
  }

  getFullResponse(pageSize: number, pageNumber: number): Observable<HttpResponse<Vacancy[]>> {
    const params = new HttpParams()
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString());
    return this.apiService.getFullResponse(`/${this.ctrlUrl}`, params);
  }

  getAdminResponse(searchString: string, searchField: string, sortField: string, sortOrder: boolean, pageSize: number, pageNumber: number)
  : Observable<HttpResponse<Vacancy[]>> {
    const params = new HttpParams()
      .set('sortField', sortField)
      .set('sortOrder', sortOrder.toString())
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString())
      .set('searchString', searchString)
      .set('searchField', searchField);

    return this.apiService.getFullResponse(`/${this.ctrlUrl}/filtered`, params);
  }

  getAll(): Observable<Vacancy[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getByRecruiterId(id: number): Observable<Vacancy[]> {
    return this.apiService.get(`/${this.ctrlUrl}/recruiter/${id}`);
  }

  getByFilter(param: JobSearchQuery, pageSize: number, pageNumber: number): Observable<HttpResponse<Vacancy[]>> {
    let params = new HttpParams()
      .set('name', param.name)
      .set('city', param.city)
      .set('workArea', param.workArea)
      .set('typeOfEmployment', param.typeOfEmployment)
      .set('isChecked', param.isChecked.toString())
      .set('salary', param.salary.toString())
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString());
      param.namesOfCompanies.forEach(nameOfCompany => {
        params = params.append('namesOfCompanies', nameOfCompany);
      });
    return this.apiService.getFullResponse(`/${this.ctrlUrl}/filtered`, params);
  }

  getById(id: number): Observable<Vacancy> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
}

  create(request: VacancyRequest): Observable<Vacancy> {
    return this.apiService.post(`/${this.ctrlUrl}`, request);
  }

  update(id: number, request: VacancyRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}
