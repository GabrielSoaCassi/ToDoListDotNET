import { Lista } from './../../models/lista.model';
import { ListaService } from './lista.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-lista',
  templateUrl: './lista.component.html',
  styleUrls: ['./lista.component.scss'],
})
export class ListaComponent implements OnInit {
  listas?: Lista[];

  constructor(private listaService: ListaService) {}

  ngOnInit(): void {
    this.listaService.pesquisar().subscribe((lista) => (this.listas = lista));
  }
}
