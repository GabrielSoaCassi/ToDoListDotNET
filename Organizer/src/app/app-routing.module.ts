import { DeletartarefaComponent } from './components/tarefa/operacoes/deletartarefa/deletartarefa.component';
import { DeletarComponent } from './components/lista/operacoes/deletar/deletar.component';
import { MainComponent } from './components/template/main/main.component';
import { AdicionarlistaComponent } from './components/lista/operacoes/adicionarlista/adicionarlista.component';
import { AdicionartarefaComponent } from './components/tarefa/operacoes/adicionartarefa/adicionartarefa.component';

import { ListaComponent } from './components/lista/lista.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: 'listas', component: ListaComponent},
  {path: 'tarefas/adicionar', component:AdicionartarefaComponent},
  {path: 'listas/adicionar', component:AdicionarlistaComponent},
  {path: '', component:MainComponent},
  {path: 'listas/deletar', component:DeletarComponent},
  {path: 'tarefas/deletar', component:DeletartarefaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
