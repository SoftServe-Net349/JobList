import { Injectable } from '@angular/core';
import { City } from '../../shared/models/city.model';
import { Observable } from 'rxjs';
import { CityRequest } from '../../shared/models/city-request.model';
import { ApiService } from './api.service';

@Injectable()
export class CityService {
  private ctrlUrl = 'cities';

  constructor(private apiService: ApiService) {
  }

  getAll(): Observable<City[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getById(id: number): Observable<City> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
}

  create(request: CityRequest): Observable<City> {
    return this.apiService.post(`/${this.ctrlUrl}`, request);
  }

  update(id: number, request: CityRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}
