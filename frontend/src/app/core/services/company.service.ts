import { Injectable } from '@angular/core';
import { Company } from '../../shared/models/company.model';
import { Observable } from 'rxjs';
import { CompanyRequest } from '../../shared/models/company-request.model';
import { ApiService } from './api.service';
import { HttpParams, HttpResponse } from '@angular/common/http';
import { CompanyUpdateRequest } from '../../shared/models/company-update-request.model';
import { PaginationQuery } from 'src/app/shared/filterQueries/PaginationQuery';
import { SearchingQuery } from 'src/app/shared/filterQueries/SearchingQuery';
import { SortingQuery } from 'src/app/shared/filterQueries/SortingQuery';


@Injectable()
export class CompanyService {

  private ctrlUrl = 'companies';

  constructor(private apiService: ApiService) {}

  getFullResponse(searching: SearchingQuery, sorting: SortingQuery, pagination: PaginationQuery): Observable<HttpResponse<Company[]>> {
    const params = new HttpParams()
      .set('sortField', sorting.sortField)
      .set('sortOrder', sorting.sortOrder.toString())
      .set('pageSize', pagination.pageSize.toString())
      .set('pageNumber', pagination.pageNumber.toString())
      .set('searchString', searching.searchString)
      .set('searchField', searching.searchField);

    return this.apiService.getFullResponse(`/${this.ctrlUrl}/filtered`, params);
  }

  getAll(): Observable<Company[]> {
    return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getById(id: number): Observable<Company> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
  }

  register(request: CompanyRequest): Observable<Company> {
    return this.apiService.post(`/${this.ctrlUrl}/register`, request);
  }

  update(id: number, request: CompanyUpdateRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }

}
