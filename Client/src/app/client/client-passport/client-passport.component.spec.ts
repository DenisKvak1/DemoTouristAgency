import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientPassportComponent } from './client-passport.component';

describe('ClientPassportComponent', () => {
  let component: ClientPassportComponent;
  let fixture: ComponentFixture<ClientPassportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ClientPassportComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientPassportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
