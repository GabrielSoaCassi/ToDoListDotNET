import { Tarefa } from './../../models/tarefa.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


var url = 'https://localhost:5001'
@Injectable({
  providedIn: 'root',
})
export class TarefaService {
  constructor(private http: HttpClient) {}

  pesquisar = (): Observable<Tarefa[]> =>
    this.http.get<Tarefa[]>(`${url}/Tarefa`)

  pesquisarPorId = (id: number): Observable<Tarefa> =>
    this.http.get<Tarefa>(`${url}/Tarefa/${id}`)

  adicionar = (tarefa: Tarefa): Observable<Tarefa> =>
    this.http.post<Tarefa>(`${url}/Tarefa`, tarefa)

  deletar = (id: number): Observable<Tarefa> =>
    this.http.delete<Tarefa>(`${url}/Tarefa/${id}`)
}

