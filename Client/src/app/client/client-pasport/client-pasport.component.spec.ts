import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientPasportComponent } from './client-pasport.component';

describe('ClientPasportComponent', () => {
  let component: ClientPasportComponent;
  let fixture: ComponentFixture<ClientPasportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ClientPasportComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientPasportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
