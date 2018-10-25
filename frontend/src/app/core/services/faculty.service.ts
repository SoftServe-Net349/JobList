import { Injectable } from '@angular/core';
import { Faculty } from '../../shared/models/faculty.model';
import { Observable } from 'rxjs';
import { FacultyRequest } from '../../shared/models/faculty-request.model';
import { ApiService } from './api.service';

@Injectable()
export class FacultyService {
  private ctrlUrl = 'faculties';

  constructor(private apiService: ApiService) {
  }

  getAll(): Observable<Faculty[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getById(id: number): Observable<Faculty> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
 }

  create(request: FacultyRequest): Observable<Faculty> {
    return this.apiService.post(`/${this.ctrlUrl}`, request);
  }

  update(id: number, request: FacultyRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}
