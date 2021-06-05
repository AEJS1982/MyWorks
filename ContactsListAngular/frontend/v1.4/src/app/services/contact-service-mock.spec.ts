import { TestBed } from '@angular/core/testing';

import { ContactServiceMock } from './contact-service-mock';

describe('ContactService', () => {
  let service: ContactServiceMock;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ContactServiceMock);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
