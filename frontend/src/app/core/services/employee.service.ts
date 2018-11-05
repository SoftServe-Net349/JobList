import { Injectable } from '@angular/core';
import { Employee } from '../../shared/models/employee.model';
import { Observable } from 'rxjs';
import { EmployeeRequest } from '../../shared/models/employee-request.model';
import { ApiService } from './api.service';
import { HttpParams, HttpResponse } from '@angular/common/http';
import { EmployeeUpdateRequest } from '../../shared/models/employee-update-request.model';
import { SearchingQuery } from 'src/app/shared/filterQueries/SearchingQuery';
import { SortingQuery } from 'src/app/shared/filterQueries/SortingQuery';
import { PaginationQuery } from 'src/app/shared/filterQueries/PaginationQuery';
import { EmployeeResetPasswordRequest } from 'src/app/shared/models/employee-reset-password-request.model';

@Injectable()
export class EmployeeService {

  private ctrlUrl = 'employees';

  constructor(private apiService: ApiService) {}

  getAll(): Observable<Employee[]> {
    return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getFullResponse(searching: SearchingQuery, sorting: SortingQuery, pagination: PaginationQuery)
  : Observable<HttpResponse<Employee[]>> {
    const params = new HttpParams()
      .set('sortField', sorting.sortField)
      .set('sortOrder', sorting.sortOrder.toString())
      .set('pageSize', pagination.pageSize.toString())
      .set('pageNumber', pagination.pageNumber.toString())
      .set('searchString', searching.searchString)
      .set('searchField', searching.searchField);

    return this.apiService.getFullResponse(`/${this.ctrlUrl}/filtered`, params);
  }

  getById(id: number): Observable<Employee> {
    return this.apiService.getById(`/${this.ctrlUrl}`, id);
  }

  register(request: EmployeeRequest): Observable<Employee> {
    return this.apiService.post(`/${this.ctrlUrl}/register`, request);
  }

  update(id: number, request: EmployeeUpdateRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }

  resetPassword(id: number, request: EmployeeResetPasswordRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}/reset`, request);
     }

}
