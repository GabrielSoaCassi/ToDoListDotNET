import { ListaService } from './../../../lista/lista.service';
import { Lista } from './../../../../models/lista.model';
import { TarefaService } from './../../tarefa.service';
import { Tarefa } from './../../../../models/tarefa.model';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-adicionartarefa',
  templateUrl: './adicionartarefa.component.html'
})
export class AdicionartarefaComponent implements OnInit {
  constructor(
    private tarefaService: TarefaService,
    private listaSevice: ListaService
  ) {}
  listaId!: number;
  nome!: string;
  tarefa!: Tarefa;
  listas!: Lista[];

  ngOnInit(): void {
    this.listaSevice.pesquisar().subscribe((listasResponse) => {
      this.listas = listasResponse;
      console.log(this.listas);
    });
  }

  adicionar(): void {
    if(this.listaId == null || this.nome == null){
      alert("Selecione uma lista e digite um tarefa")
      throw new Error()
    }
    this.tarefa = {
      listaId: this.listaId,
      nome: this.nome,
    };
    this.tarefaService
      .adicionar(this.tarefa)
      .subscribe()
      alert('Salvo Com sucesso')
  }
}
