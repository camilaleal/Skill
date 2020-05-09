import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CadastroPerfilComponent } from './cadastro-perfil.component';

describe('CadastroPerfilComponent', () => {
  let component: CadastroPerfilComponent;
  let fixture: ComponentFixture<CadastroPerfilComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CadastroPerfilComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CadastroPerfilComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
