import { TestBed, inject } from '@angular/core/testing';

import { JQUERY_TOKEN } from "app";

describe('JqueryService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [JQUERY_TOKEN]
    });
  });

});
