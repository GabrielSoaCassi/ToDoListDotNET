import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { ListaService } from './lista.service';
import { RouterTestingModule } from '@angular/router/testing';
import { ListaComponent } from './lista.component';

describe(ListaComponent.name, () => {
  let component: ListaComponent;
  let fixture: ComponentFixture<ListaComponent>;

  beforeEach(() => {
    const listaServiceStub = () => ({
      pesquisar: () =>
      ({ subscribe: () => () => {} }),
    });
    TestBed.configureTestingModule({
      imports: [RouterTestingModule],
      schemas: [NO_ERRORS_SCHEMA],
      declarations: [ListaComponent],
      providers: [{ provide: ListaService, useFactory: listaServiceStub }],
    });
    fixture = TestBed.createComponent(ListaComponent);
    component = fixture.componentInstance;
  });

  it(' _QuandoCriado_DevePoderSerCarregado', () => {
    expect(component).toBeTruthy();
  });

  describe(ListaComponent.prototype.ngOnInit.name, () => {
    it('_QuandoChamado_DeveRetornarTodasAsListasDoBancoDeDados', () => {
      const listaServiceStub: ListaService =
        fixture.debugElement.injector.get(ListaService);
      spyOn(listaServiceStub, 'pesquisar').and.callThrough();
      component.ngOnInit();
      expect(listaServiceStub.pesquisar).toHaveBeenCalled();
    });
  });
});
