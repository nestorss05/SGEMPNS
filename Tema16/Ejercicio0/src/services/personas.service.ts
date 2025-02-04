import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Persona } from '../interfaces/persona';

@Injectable({
  providedIn: 'root'
})
export class PersonasService {

  /*URL de mi aPI para usar en todo el Servicio*/
  urlWebAPI='https://nestorsanchezasp.azurewebsites.net/API/Personas';

  constructor() { }
  http=inject(HttpClient);

  getPersonas(): Observable<Persona[]>{
    return this.http.get<Persona[]>(this.urlWebAPI);
  }

  postPersonas(per: Partial<Persona>): Observable<Persona>{
    return this.http.post<Persona>(this.urlWebAPI, per);
  }

  deletePersonas(id: Number): Observable<void> {
    return this.http.delete<void>(this.urlWebAPI + "/" + id);
  }

}
