import { Injectable } from '@angular/core';
import { Recruiter } from '../../shared/models/recruiter.model';
import { Observable } from 'rxjs';
import { RecruiterRequest } from '../../shared/models/recruiter-request.model';
import { ApiService } from './api.service';

@Injectable()
export class RecruiterService {
  private ctrlUrl = 'recruiters';

  constructor(private apiService: ApiService) {
  }

  getAll(): Observable<Recruiter[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getByCompanyId(id: number): Observable<Recruiter[]> {
    return this.apiService.get(`/${this.ctrlUrl}/company/${id}`);
  }
  getById(id: number): Observable<Recruiter> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
  }

  create(request: RecruiterRequest): Observable<Recruiter> {
    return this.apiService.post(`/${this.ctrlUrl}`, request);
  }

  update(id: number, request: RecruiterRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}
