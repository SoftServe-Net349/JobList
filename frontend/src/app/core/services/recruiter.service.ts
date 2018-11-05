import { Injectable } from '@angular/core';
import { Recruiter } from '../../shared/models/recruiter.model';
import { Observable } from 'rxjs';
import { RecruiterRequest } from '../../shared/models/recruiter-request.model';
import { ApiService } from './api.service';
import { HttpParams, HttpResponse } from '@angular/common/http';
import { RecruiterUpdateRequest } from '../../shared/models/recruiter-update-request.model';
import { SearchingQuery } from 'src/app/shared/filterQueries/SearchingQuery';
import { SortingQuery } from 'src/app/shared/filterQueries/SortingQuery';
import { PaginationQuery } from 'src/app/shared/filterQueries/PaginationQuery';

@Injectable()
export class RecruiterService {

  private ctrlUrl = 'recruiters';

  constructor(private apiService: ApiService) {
  }

  getAll(): Observable<Recruiter[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getFullResponse(searching: SearchingQuery, sorting: SortingQuery, pagination: PaginationQuery)
  : Observable<HttpResponse<Recruiter[]>> {
    const params = new HttpParams()
      .set('sortField', sorting.sortField)
      .set('sortOrder', sorting.sortOrder.toString())
      .set('pageSize', pagination.pageSize.toString())
      .set('pageNumber', pagination.pageNumber.toString())
      .set('searchString', searching.searchString)
      .set('searchField', searching.searchField);

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

  getFilteredRecruiters(id: number, search: string, pageSize: number, pageNumber: number)
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
