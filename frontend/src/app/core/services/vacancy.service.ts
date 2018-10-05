import { Injectable } from '@angular/core';
import { Vacancy } from '../../shared/models/vacancy.model';
import { Observable } from 'rxjs';
import { VacancyRequest } from '../../shared/models/vacancy-request.model';
import { ApiService } from './api.service';
import { HttpResponse } from '@angular/common/http';

@Injectable()
export class VacancyService {
  private ctrlUrl = 'vacancies';

  constructor(private apiService: ApiService) {
  }

  getAll(pageCount: number, pageNumber: number): Observable<Vacancy[]> {
      return this.apiService.get(`/${this.ctrlUrl}?pageCount=${pageCount}&pageNumber=${pageNumber}`);
  }

  getByRecruitersId(id: number): Observable<Vacancy[]> {
    return this.apiService.get(`/${this.ctrlUrl}/recruiters/${id}`);
  }

  getBySearchString(searchString: String, pageCount: number, pageNumber: number): Observable<Vacancy[]> {
    return this.apiService.get(`/${this.ctrlUrl}/search/${searchString}?pageCount=${pageCount}&pageNumber=${pageNumber}`);
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
