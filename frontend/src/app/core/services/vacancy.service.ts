import { Injectable } from '@angular/core';
import { Vacancy } from '../../shared/models/vacancy.model';
import { Observable } from 'rxjs';
import { VacancyRequest } from '../../shared/models/vacancy-request.model';
import { ApiService } from './api.service';
import { HttpParams, HttpResponse } from '@angular/common/http';

@Injectable()
export class VacancyService {
  private ctrlUrl = 'vacancies';

  constructor(private apiService: ApiService) {
  }

  getFullResponse(pageSize: number, pageNumber: number): Observable<HttpResponse<Vacancy[]>>{
    const params = new HttpParams()
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString());
    return this.apiService.getFullResponse(`/${this.ctrlUrl}`, params);
  }

  getAll(): Observable<Vacancy[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getByRecruiterId(id: number): Observable<Vacancy[]> {
    return this.apiService.get(`/${this.ctrlUrl}/recruiter/${id}`);
  }

  getBySearchString(search: string, city: string, pageSize: number, pageNumber: number): Observable<HttpResponse<Vacancy[]>> {
    const params = new HttpParams()
      .set('search', search)
      .set('city', city)
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString());

    return this.apiService.getFullResponse(`/${this.ctrlUrl}/search`, params);
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
