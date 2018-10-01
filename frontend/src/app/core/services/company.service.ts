import { Injectable } from '@angular/core';
import { Company } from '../../shared/models/company.model';
import { Observable } from 'rxjs';
import { CompanyRequest } from '../../shared/models/company-request.model';
import { ApiService } from './api.service';

@Injectable()
export class CompanyService {
  private ctrlUrl = 'companies';

  constructor(private apiService: ApiService) {
  }

  getAll(): Observable<Company[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getById(id: number): Observable<Company> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
}

  create(request: CompanyRequest): Observable<Company> {
    return this.apiService.post(`/${this.ctrlUrl}`, request);
  }

  update(id: number, request: CompanyRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}