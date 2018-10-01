import { Injectable } from '@angular/core';
import { School } from '../../shared/models/school.model';
import { Observable } from 'rxjs';
import { SchoolRequest } from '../../shared/models/school-request.model';
import { ApiService } from './api.service';

@Injectable()
export class SchoolService {
  private ctrlUrl = 'schools';

  constructor(private apiService: ApiService) {
  }

  getAll(): Observable<School[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getById(id: number): Observable<School> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
}

  create(request: SchoolRequest): Observable<School> {
    return this.apiService.post(`/${this.ctrlUrl}`, request);
  }

  update(id: number, request: SchoolRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}