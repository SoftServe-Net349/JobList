import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { ResumeRequest } from '../../shared/models/resume-request.model';
import { Resume } from '../../shared/models/resume.model';
import { HttpParams } from '@angular/common/http';

@Injectable()
export class ResumeService {
  private ctrlUrl = 'resumes';

  constructor(private apiService: ApiService) {
  }
  getAll(): Observable<Resume[]> {
    return this.apiService.get(`/${this.ctrlUrl}`);
}
  getBySearchString(search: string, city: string): Observable<Resume[]> {
    const params = new HttpParams()
    .set('search', search)
    .set('city', city);
    return this.apiService.get(`/${this.ctrlUrl}/search`, params);
  }

  getById(id: number): Observable<Resume> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
}

  create(request: ResumeRequest): Observable<Resume> {
    return this.apiService.post(`/${this.ctrlUrl}`, request);
  }

  update(id: number, request: ResumeRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}