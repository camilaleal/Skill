import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BuscarOportunidadeComponent } from './buscar-oportunidade.component';

describe('BuscarOportunidadeComponent', () => {
  let component: BuscarOportunidadeComponent;
  let fixture: ComponentFixture<BuscarOportunidadeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BuscarOportunidadeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BuscarOportunidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
