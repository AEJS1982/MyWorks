import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContactEditorComponentv2 } from './contact-editor.component-v2';

describe('ContactItemComponent', () => {
  let component: ContactEditorComponentv2;
  let fixture: ComponentFixture<ContactEditorComponentv2>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContactEditorComponentv2 ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ContactEditorComponentv2);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
