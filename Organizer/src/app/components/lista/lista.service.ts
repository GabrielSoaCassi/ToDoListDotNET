import { Lista } from './../../models/lista.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

var url = 'https://localhost:5001'
@Injectable({
  providedIn: 'root',
})
export class ListaService {
  constructor(private http: HttpClient) {}

  pesquisar = (): Observable<Lista[]> =>
    this.http.get<Lista[]>(`${url}/Lista`);

  pesquisarPorId = (id: number): Observable<Lista> =>
    this.http.get<Lista>(`${url}/Lista/${id}`);

  adicionar = (nomeLista: Lista): Observable<Lista> =>
    this.http.post<Lista>(`${url}/Lista`, nomeLista);

  deletar = (id: number): Observable<Lista> =>
    this.http.delete<Lista>(`${url}/Lista/${id}`);
}
