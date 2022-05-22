import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { FormsModule } from '@angular/forms'
import { AppRoutingModule } from './app-routing.module'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { HttpClientModule} from '@angular/common/http'
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { ModalModule } from 'ngx-bootstrap/modal';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppComponent } from './app.component'
import { FooterComponent } from './components/template/footer/footer.component'
import { NavComponent } from './components/template/nav/nav.component'
import { ListaComponent } from './components/lista/lista.component'
import { MainComponent } from './components/template/main/main.component';
import { AdicionartarefaComponent } from './components/tarefa/operacoes/adicionartarefa/adicionartarefa.component';
import { AdicionarlistaComponent } from './components/lista/operacoes/adicionarlista/adicionarlista.component';
import { DeletarComponent } from './components/lista/operacoes/deletar/deletar.component';
import { DeletartarefaComponent } from './components/tarefa/operacoes/deletartarefa/deletartarefa.component';

@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    NavComponent,
    ListaComponent,
    MainComponent,
    AdicionartarefaComponent,
    AdicionarlistaComponent,
    DeletarComponent,
    DeletartarefaComponent,
  ],
  imports: [
    FormsModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    BsDropdownModule,
    TooltipModule,
    ModalModule,
    NgbModule,
    FontAwesomeModule
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
