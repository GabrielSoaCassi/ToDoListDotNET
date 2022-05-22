import { ListaService } from './../../lista.service';
import { Component, OnInit } from '@angular/core';
import { Lista } from 'src/app/models/lista.model';

@Component({
  selector: 'app-deletar',
  templateUrl: './deletar.component.html'
})
export class DeletarComponent implements OnInit {
  listaId!: number;
  lista!: Lista[];
  constructor(private listaService: ListaService) {}

  ngOnInit(): void {
    this.listaService.pesquisar().subscribe((listas) => (this.lista = listas));
  }

  deletar(): void {
    if(this.listaId == null){
      alert("selecione uma Lista")
      throw new Error
    }
    this.listaService.deletar(this.listaId).subscribe();
    alert('Lista Deletada com sucesso');
    this.listaId = 0;
  }
}
