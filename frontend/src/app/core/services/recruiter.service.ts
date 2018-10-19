import { Injectable } from '@angular/core';
import { Recruiter } from '../../shared/models/recruiter.model';
import { Observable } from 'rxjs';
import { RecruiterRequest } from '../../shared/models/recruiter-request.model';
import { ApiService } from './api.service';
import { HttpParams, HttpResponse } from '@angular/common/http';
import { RecruiterUpdateRequest } from '../../shared/models/recruiter-update-request.model';

@Injectable()
export class RecruiterService {
  private ctrlUrl = 'recruiters';

  constructor(private apiService: ApiService) {
  }

  getAll(): Observable<Recruiter[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getFullResponse(searchString: string, sortField: string, sortOrder: boolean, pageSize: number, pageNumber: number)
  : Observable<HttpResponse<Recruiter[]>> {
    const params = new HttpParams()
      .set('sortField', sortField)
      .set('sortOrder', sortOrder.toString())
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString())
      .set('searchString', searchString);

    return this.apiService.getFullResponse(`/${this.ctrlUrl}/filtered`, params);
  }

  getByCompanyId(id: number): Observable<Recruiter[]> {
    return this.apiService.get(`/${this.ctrlUrl}/company/${id}`);
  }

  getById(id: number): Observable<Recruiter> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
  }

  getByCompanyIdWithPagination(id: number, pageSize: number, pageNumber: number): Observable<HttpResponse<Recruiter[]>> {
    const params = new HttpParams()
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString());
    return this.apiService.getFullResponse(`/${this.ctrlUrl}/company/${id}`, params);
  }

  getByCompanyIdSearchStringWithPagination(id: number, search: string, pageSize: number, pageNumber: number)
  : Observable<HttpResponse<Recruiter[]>> {
    const params = new HttpParams()
      .set('searchString', search)
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString());
    return this.apiService.getFullResponse(`/${this.ctrlUrl}/company/${id}/filtered`, params);
  }

  register(request: RecruiterRequest): Observable<Recruiter> {
    return this.apiService.post(`/${this.ctrlUrl}/register`, request);
  }

  update(id: number, request: RecruiterUpdateRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}
