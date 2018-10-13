import { Injectable } from '@angular/core';
import { User } from '../../shared/models/user.model';
import { Observable } from 'rxjs';
import { UserRequest } from '../../shared/models/user-request.model';
import { ApiService } from './api.service';

@Injectable()
export class UserService {
  private ctrlUrl = 'users';

  constructor(private apiService: ApiService) {
  }

  getAll(): Observable<User[]> {
      return this.apiService.get(`/${this.ctrlUrl}`);
  }

  getById(id: number): Observable<User> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
}

  register(request: UserRequest): Observable<User> {
    return this.apiService.post(`/${this.ctrlUrl}/register`, request);
  }

  update(id: number, request: UserRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}
