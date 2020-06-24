import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroOportunidadeComponent } from './cadastro-oportunidade.component';

describe('CadastroOportunidadeComponent', () => {
  let component: CadastroOportunidadeComponent;
  let fixture: ComponentFixture<CadastroOportunidadeComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroOportunidadeComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroOportunidadeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
