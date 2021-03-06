import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IResponse } from '../shared/models/response';

@Injectable({
  providedIn: 'root'
})
export class CmsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }


}
