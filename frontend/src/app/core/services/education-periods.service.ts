import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EducationPeriodRequest } from '../../shared/models/education-period-request.model';
import { ApiService } from './api.service';
import { EducationPeriod } from '../../shared/models/education-period.model';

@Injectable({
  providedIn: 'root'
})
export class EducationPeriodsService {

  private ctrlUrl = 'educationPeriods';

  constructor(private apiService: ApiService) {
  }

  getAll(): Observable<EducationPeriod[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getById(id: number): Observable<EducationPeriod> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
  }

  create(request: EducationPeriodRequest): Observable<EducationPeriod> {
    return this.apiService.post(`/${this.ctrlUrl}`, request);
  }

  update(id: number, request: EducationPeriodRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}
