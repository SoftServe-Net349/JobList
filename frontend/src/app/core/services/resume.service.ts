import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { ResumeRequest } from '../../shared/models/resume-request.model';
import { Resume } from '../../shared/models/resume.model';

@Injectable()
export class ResumeService {
  private ctrlUrl = 'resumes';

  constructor(private apiService: ApiService) {
  }

  getAll(): Observable<Resume[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getBySearchString(searchString: String): Observable<Resume[]> {
    return this.apiService.get(`/${this.ctrlUrl}/search/${searchString}`);
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