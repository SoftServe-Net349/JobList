import { Injectable } from '@angular/core';
import { Invitation } from '../../shared/models/invitation.model';
import { Observable } from 'rxjs';
import { InvitationRequest } from '../../shared/models/invitation-request.model';
import { ApiService } from './api.service';
import { HttpResponse, HttpParams } from '@angular/common/http';

@Injectable()
export class InvitationService {
  private ctrlUrl = 'invitations';

  constructor(private apiService: ApiService) {
  }

  getAll(): Observable<Invitation[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getById(id: number): Observable<Invitation> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
  }

  getByEmployeeId(id: number, pageSize: number, pageNumber: number): Observable<HttpResponse<Invitation[]>> {
    const params = new HttpParams()
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString());
    return this.apiService.getFullResponse(`/${this.ctrlUrl}/employee/${id}`, params);
  }

  create(request: InvitationRequest): Observable<Invitation> {
    return this.apiService.post(`/${this.ctrlUrl}`, request);
  }

  update(id: number, request: InvitationRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}
