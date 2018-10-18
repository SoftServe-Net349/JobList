import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { ResumeRequest } from '../../shared/models/resume-request.model';
import { Resume } from '../../shared/models/resume.model';
import { HttpParams, HttpResponse } from '@angular/common/http';
import { ResumessearchQuery } from 'src/app/shared/filterQueries/ResumessearchQuery';

@Injectable()
export class ResumeService {
  private ctrlUrl = 'resumes';

  constructor(private apiService: ApiService) {
  }

  getFullResponse(pageSize: number, pageNumber: number): Observable<HttpResponse<Resume[]>>{
    const params = new HttpParams()
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString());

    return this.apiService.getFullResponse(`/${this.ctrlUrl}`, params);
  }

  getByFilter(param: ResumessearchQuery, pageSize: number, pageNumber: number): Observable<HttpResponse<Resume[]>> {
    let params = new HttpParams()
      .set('name', param.name)
      .set('city', param.city)
      .set('workArea', param.workArea)
      .set('age', param.age.toString())
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString());
      param.schools.forEach(school => {
        params = params.append('schools', school);
      });
      param.schools.forEach(faculty => {
        params = params.append('faculties', faculty);
      });
      param.schools.forEach(language => {
        params = params.append('languages', language);
      });
    return this.apiService.getFullResponse(`/${this.ctrlUrl}/filtered`, params);
  }


  getAll(): Observable<Resume[]> {
    return this.apiService.get(`/${this.ctrlUrl}`);
  }
  getBySearchString(search: string, city: string, pageSize: number, pageNumber: number): Observable<HttpResponse<Resume[]>> {
    const params = new HttpParams()
      .set('search', search)
      .set('city', city)
      .set('pageSize', pageSize.toString())
      .set('pageNumber', pageNumber.toString());

    return this.apiService.getFullResponse(`/${this.ctrlUrl}/search`, params);
  }

  getById(id: number): Observable<Resume> {
    return this.apiService.get(`/${this.ctrlUrl}/${id}`);
}

  create(request: ResumeRequest): Observable<Resume> {
    return this.apiService.post(`/${this.ctrlUrl}`, request);
  }

  update(id: number, request: ResumeRequest): Observable<Object> {
    return this.apiService.put(`/${this.ctrlUrl}/${id}`, request);
  }

  delete(id: number): Observable<Object> {
    return this.apiService.delete(`/${this.ctrlUrl}/${id}`);
  }
}