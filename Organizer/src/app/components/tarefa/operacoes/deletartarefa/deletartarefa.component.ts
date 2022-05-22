import { Tarefa } from './../../../../models/tarefa.model';
import { TarefaService } from './../../tarefa.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-deletartarefa',
  templateUrl: './deletartarefa.component.html',

})
export class DeletartarefaComponent implements OnInit {
  tarefaId!: number;
  tarefas!: Tarefa[];
  constructor(private tarefaService: TarefaService) {}

  ngOnInit(): void {
    this.tarefaService
      .pesquisar()
      .subscribe((tarefas) => (this.tarefas = tarefas));
  }

  deletar(): void {
    if (this.tarefaId == null) {
      alert('Selecione uma Tarefa')
      throw new Error('Id não existente')
    }
    this.tarefaService.deletar(this.tarefaId).subscribe();
    alert('Tarefa excluida com sucesso');
  }
}
