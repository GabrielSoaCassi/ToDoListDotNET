import { Tarefa } from '../../../../models/tarefa.model';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { ListaService } from '../../../lista/lista.service';
import { TarefaService } from '../../tarefa.service';
import { FormsModule } from '@angular/forms';
import { AdicionartarefaComponent } from './adicionartarefa.component';

describe(AdicionartarefaComponent.name, () => {
  let component: AdicionartarefaComponent;
  let fixture: ComponentFixture<AdicionartarefaComponent>;

  beforeEach(() => {
    const listaServiceStub = () => ({
      pesquisar: () =>
        ({ subscribe: () => () => {} })
    });
    const tarefaServiceStub = () => ({
      adicionar: (tarefa: Tarefa) =>
        ({ subscribe: () => () => {} })
    });
    TestBed.configureTestingModule({
      imports: [FormsModule],
      schemas: [NO_ERRORS_SCHEMA],
      declarations: [AdicionartarefaComponent],
      providers: [
        { provide: ListaService, useFactory: listaServiceStub },
        { provide: TarefaService, useFactory: tarefaServiceStub }
      ]
    });
    fixture = TestBed.createComponent(AdicionartarefaComponent);
    component = fixture.componentInstance;
  });

  it(`${AdicionartarefaComponent.name}
  _QuandoCriado_DevePoderSerCarregado`, () => {
    expect(component).toBeTruthy();
  });

  describe(`${AdicionartarefaComponent.prototype.ngOnInit.name}`, () => {
    it('_QuandoChamado_DeveCarregarAsTarefasExistentesNoBancoDeDados', () => {
      const listaServiceStub: ListaService = fixture.debugElement.injector.get(
        ListaService
      );
      spyOn(listaServiceStub, 'pesquisar').and.callThrough();
      component.ngOnInit();
      expect(listaServiceStub.pesquisar).toHaveBeenCalled();
    });
  });

  describe(`${AdicionartarefaComponent.prototype.adicionar.name}`, () => {
    it('_QuandoReceberParametrosValidos_DeveAdicionarAsTarefasEmUmaListaExistenteNoBancoDeDados', () => {
      const tarefaServiceStub: TarefaService = fixture.debugElement.injector.get(
        TarefaService
      );
      spyOn(tarefaServiceStub, 'adicionar').and.callThrough();
      component.listaId = 1
      component.nome = "QQQ"
      component.adicionar();
      expect(tarefaServiceStub.adicionar).toHaveBeenCalled();
    });
  });
});
