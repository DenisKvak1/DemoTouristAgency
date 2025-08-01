import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientTagsPickerComponent } from './client-tags-picker.component';

describe('ClientTagsPickerComponent', () => {
  let component: ClientTagsPickerComponent;
  let fixture: ComponentFixture<ClientTagsPickerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ClientTagsPickerComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientTagsPickerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
