import { Injectable } from '@angular/core';
import { Company } from '../../shared/models/company.model';
import { Observable } from 'rxjs';
import { CompanyRequest } from '../../shared/models/company-request.model';
import { ApiService } from './api.service';
import { HttpParams, HttpResponse } from '@angular/common/http';

@Injectable()
export class CompanyService {
  private ctrlUrl = 'companies';

  constructor(private apiService: ApiService) {
  }

  getFullResponse(searchString: string, sortField: string, sortOrder: boolean, pageSize: number, pageNumber: number): Observable<HttpResponse<Company[]>> {
    const params = new HttpParams()
      .set('sortField', sortField)
      .set('sortOrder', sortOrder.toString())
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString())
      .set('searchString', searchString);
      
    return this.apiService.getFullResponse(`/${this.ctrlUrl}/admin`, params);
  }
  
  getAll(): Observable<Company[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getById(id: number): Observable<Company> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
}

  register(request: CompanyRequest): Observable<Company> {
    console.log(request);
    return this.apiService.post(`/${this.ctrlUrl}/register`, request);
  }

  update(id: number, request: CompanyRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}
