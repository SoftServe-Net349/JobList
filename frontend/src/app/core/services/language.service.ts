import { Injectable } from '@angular/core';
import { Language } from '../../shared/models/language.model';
import { Observable } from 'rxjs';
import { LanguageRequest } from '../../shared/models/language-request.model';
import { ApiService } from './api.service';

@Injectable()
export class LanguageService {
  private ctrlUrl = 'languages';

  constructor(private apiService: ApiService) {
  }

  getAll(): Observable<Language[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getById(id: number): Observable<Language> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
}

  create(request: LanguageRequest): Observable<Language> {
    return this.apiService.post(`/${this.ctrlUrl}`, request);
  }

  update(id: number, request: LanguageRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}