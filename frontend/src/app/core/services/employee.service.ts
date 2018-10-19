import { Injectable } from '@angular/core';
import { Employee } from '../../shared/models/employee.model';
import { Observable } from 'rxjs';
import { EmployeeRequest } from '../../shared/models/employee-request.model';
import { ApiService } from './api.service';
import { HttpParams, HttpResponse } from '@angular/common/http';

@Injectable()
export class EmployeeService {
  private ctrlUrl = 'employees';

  constructor(private apiService: ApiService) {
  }

  getAll(): Observable<Employee[]> {
    return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getFullResponse(searchString: string, sortField: string, sortOrder: boolean, pageSize: number, pageNumber: number)
  : Observable<HttpResponse<Employee[]>> {
    const params = new HttpParams()
      .set('sortField', sortField)
      .set('sortOrder', sortOrder.toString())
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString())
      .set('searchString', searchString);

    return this.apiService.getFullResponse(`/${this.ctrlUrl}/filtered`, params);
  }

  getById(id: number): Observable<Employee> {
    return this.apiService.getById(`/${this.ctrlUrl}`, id);
  }

  register(request: EmployeeRequest): Observable<Employee> {
    return this.apiService.post(`/${this.ctrlUrl}/register`, request);
  }

  update(id: number, request: EmployeeRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}
