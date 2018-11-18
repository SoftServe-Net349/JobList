import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ExperienceRequest } from '../../shared/models/experience-request.model';
import { ApiService } from './api.service';
import { Experience } from '../../shared/models/experience.model';

@Injectable({
  providedIn: 'root'
})

export class ExperienceService {

  private ctrlUrl = 'experiences';

  constructor(private apiService: ApiService) {}


  getAll(): Observable<Experience[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }


  getById(id: number): Observable<Experience> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
  }

  create(request: ExperienceRequest): Observable<Experience> {
    return this.apiService.post(`/${this.ctrlUrl}`, request);
  }

  update(id: number, request: ExperienceRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }

}
