import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { BehaviorSubject, Observable } from 'rxjs'; 
import { Directory } from '../_models/Directory';

@Injectable({
  providedIn: 'root',
})
export class StructureService {
  private baseUrl = environment.baseUrl;
  public folder = new BehaviorSubject(null);

  constructor(private http: HttpClient) {}

  public getStructure(path: string): Observable<Directory> {
    return this.http.get<Directory>(this.baseUrl + 'api/directories', {
      params: new HttpParams().set('path', path),
    });
  }

  public uploadJsonStructure(formData: FormData) {
    formData.append('folder', this.folder.value);
    return this.http.post(this.baseUrl + 'api/directories', formData);
  }
}
