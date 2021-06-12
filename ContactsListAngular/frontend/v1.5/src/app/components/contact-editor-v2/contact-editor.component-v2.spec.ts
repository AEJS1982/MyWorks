import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { provideMockStore } from '@ngrx/store/testing';

import { ContactEditorComponentv2 } from './contact-editor.component-v2';

describe('ContactItemComponentv2', () => {
  let component: ContactEditorComponentv2;
  let fixture: ComponentFixture<ContactEditorComponentv2>;
  const initialState = {};

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ContactEditorComponentv2 ],
      imports:[
        ReactiveFormsModule,
        RouterTestingModule,
        HttpClientTestingModule
      ],
      providers:[
        provideMockStore({initialState})
      ],
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
