import { Lista } from './../../../../models/lista.model';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { ListaService } from './../../lista.service';
import { FormsModule } from '@angular/forms';
import { DeletarComponent } from './deletar.component';

describe(DeletarComponent.name, () => {
  let component: DeletarComponent;
  let fixture: ComponentFixture<DeletarComponent>;

  beforeEach(() => {
    const listaServiceStub = () => ({
      pesquisar: () =>
       ({ subscribe:() => ()=> {} }),
      deletar: (listaId:Lista) =>
       ({ subscribe: () => () => {} })
    });
    TestBed.configureTestingModule({
      imports: [FormsModule],
      schemas: [NO_ERRORS_SCHEMA],
      declarations: [DeletarComponent],
      providers: [{ provide: ListaService, useFactory: listaServiceStub }]
    });
    fixture = TestBed.createComponent(DeletarComponent);
    component = fixture.componentInstance;
  });

  it('_QuandoCriado_DevePoderSerCarregado', () => {
    expect(component).toBeTruthy();
  });

  describe(DeletarComponent.prototype.ngOnInit.name, () => {
    it('_QuandoChamado_DeveRetornarTodasAsListasDoBancoDeDados', () => {
      const listaServiceStub: ListaService = fixture.debugElement.injector.get(
        ListaService
      );
      spyOn(listaServiceStub, 'pesquisar').and.callThrough();
      component.ngOnInit();
      expect(listaServiceStub.pesquisar).toHaveBeenCalled();
    });
  });

  describe(DeletarComponent.prototype.deletar.name, () => {
    it('_QuandoChamadoComParametrosValidos_DeveDeletarListaDoBancoDeDados', () => {
      const listaServiceStub: ListaService = fixture.debugElement.injector.get(
        ListaService
      );
      spyOn(listaServiceStub, 'deletar').and.callThrough();
      component.listaId = 1
      component.deletar();
      expect(listaServiceStub.deletar).toHaveBeenCalled();
    });
  });
});
