import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { ResumeRequest } from '../../shared/models/resume-request.model';
import { Resume } from '../../shared/models/resume.model';
import { HttpParams, HttpResponse } from '@angular/common/http';

@Injectable()
export class ResumeService {
  private ctrlUrl = 'resumes';

  constructor(private apiService: ApiService) {
  }

  getFullResponse(pageSize: number, pageNumber: number): Observable<HttpResponse<Resume[]>>{
    const params = new HttpParams()
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString());

    return this.apiService.getFullResponse(`/${this.ctrlUrl}`, params);
  }

  getAll(): Observable<Resume[]> {
    return this.apiService.get(`/${this.ctrlUrl}`);
  }
  getBySearchString(search: string, city: string, pageSize: number, pageNumber: number): Observable<HttpResponse<Resume[]>> {
    const params = new HttpParams()
      .set('search', search)
      .set('city', city)
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString());

    return this.apiService.getFullResponse(`/${this.ctrlUrl}/search`, params);
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