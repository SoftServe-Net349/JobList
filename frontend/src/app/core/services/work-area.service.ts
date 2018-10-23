import { Injectable } from '@angular/core';
import { WorkArea } from '../../shared/models/work-area.model';
import { Observable } from 'rxjs';
import { WorkAreaRequest } from '../../shared/models/work-area-request.model';
import { ApiService } from './api.service';

@Injectable()
export class WorkAreaService {
  private ctrlUrl = 'workareas';

  constructor(private apiService: ApiService) {
  }

  getAll(): Observable<WorkArea[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getById(id: number): Observable<WorkArea> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
}

  create(request: WorkAreaRequest): Observable<WorkArea> {
    return this.apiService.post(`/${this.ctrlUrl}`, request);
  }

  update(id: number, request: WorkAreaRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}
