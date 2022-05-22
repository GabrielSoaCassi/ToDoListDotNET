import { Lista } from './../../../../models/lista.model';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { ListaService } from './../../lista.service';
import { FormsModule } from '@angular/forms';
import { AdicionarlistaComponent } from './adicionarlista.component';

describe(AdicionarlistaComponent.name, () => {
  let component: AdicionarlistaComponent;
  let fixture: ComponentFixture<AdicionarlistaComponent>;

  beforeEach(() => {
    const listaServiceStub = () => ({
      adicionar: (lista:Lista) => ({ subscribe: () => () => {} })
    });
    TestBed.configureTestingModule({
      imports: [FormsModule],
      schemas: [NO_ERRORS_SCHEMA],
      declarations: [AdicionarlistaComponent],
      providers: [{ provide: ListaService, useFactory: listaServiceStub }]
    });
    fixture = TestBed.createComponent(AdicionarlistaComponent);
    component = fixture.componentInstance;
  });

  it(' _QuandoCriado_DevePoderSerCarregado', () => {
    expect(component).toBeTruthy();
  });

  describe(AdicionarlistaComponent.prototype.adicionar.name, () => {
    it('_QuandoReceberParametrosValidos_DeveAdicionarUmaListaNoBancoDeDados', () => {
      const listaServiceStub: ListaService = fixture.debugElement.injector.get(
        ListaService
      );
      spyOn(listaServiceStub, 'adicionar').and.callThrough();
      component.adicionar();
      expect(listaServiceStub.adicionar).toHaveBeenCalled();
    });
  });
});
