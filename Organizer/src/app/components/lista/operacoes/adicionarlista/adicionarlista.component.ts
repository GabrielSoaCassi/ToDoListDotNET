import { ListaService } from './../../lista.service';
import { Component } from '@angular/core';
import { Lista } from 'src/app/models/lista.model';

@Component({
  selector: 'app-adicionarlista',
  templateUrl: './adicionarlista.component.html'
})
export class AdicionarlistaComponent {
  nome!: string;
  lista!: Lista;
  constructor(private listaService: ListaService) {}

  adicionar(): void {
    if (this.nome == null && this.nome == '' && this.nome == undefined) {
      alert('Nome não pode ser nulo');
      throw new Error('nome não pode ser nulo');
    }
    this.lista = {
      nome: this.nome,
    };
    this.listaService.adicionar(this.lista).subscribe();
    alert('Lista Criada Com sucesso');
  }
}
