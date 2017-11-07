import { TestBed, async, inject } from '@angular/core/testing';

import { IsAdminGuard } from './is-admin.guard';

describe('IsAdminGuardGuard', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [IsAdminGuard]
    });
  });

  xit('should ...', inject([IsAdminGuard], (guard: IsAdminGuard) => {
    expect(guard).toBeTruthy();
  }));
});
