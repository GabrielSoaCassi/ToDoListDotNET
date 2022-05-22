import { Tarefa } from './../../../../models/tarefa.model';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { TarefaService } from './../../tarefa.service';
import { FormsModule } from '@angular/forms';
import { DeletartarefaComponent } from './deletartarefa.component';

describe(DeletartarefaComponent.name, () => {
  let component: DeletartarefaComponent;
  let fixture: ComponentFixture<DeletartarefaComponent>;

  beforeEach(() => {
    const tarefaServiceStub = () => ({
      pesquisar: () =>
        ({ subscribe: () => () => {} }),
      deletar: (tarefaId: Tarefa) =>
        ({ subscribe: () => () => {} }),
    });
    TestBed.configureTestingModule({
      imports: [FormsModule],
      schemas: [NO_ERRORS_SCHEMA],
      declarations: [DeletartarefaComponent],
      providers: [{ provide: TarefaService, useFactory: tarefaServiceStub }],
    });
    fixture = TestBed.createComponent(DeletartarefaComponent);
    component = fixture.componentInstance;
  });

  it('_QuandoCriado_DevePoderSerCarregado', () => {
    expect(component).toBeTruthy();
  });

  describe(DeletartarefaComponent.name, () => {
    it(`${DeletartarefaComponent.prototype.ngOnInit.name}_QuandoChamado_DeveMostrarTodasListasExistentesNoBd`, () => {
      const tarefaServiceStub: TarefaService =
        fixture.debugElement.injector.get(TarefaService);
      spyOn(tarefaServiceStub, 'pesquisar').and.callThrough();
      component.ngOnInit();
      expect(tarefaServiceStub.pesquisar).toHaveBeenCalled();
    });
  });

  describe(`${DeletartarefaComponent.prototype.deletar.name}_QuandoChamadoComParametrosValidos_DeveDeletarTarefaDoBancoDeDados`, () => {
    it('makes expected calls', () => {
      const tarefaServiceStub: TarefaService =
        fixture.debugElement.injector.get(TarefaService);
      spyOn(tarefaServiceStub, 'deletar').and.callThrough();
      component.tarefaId=1
      component.deletar();
      expect(tarefaServiceStub.deletar).toHaveBeenCalled();
    });
  });
});
