import { TestBed, inject } from '@angular/core/testing';

import { LocalStorageService } from './local-storage.service';

// used to test local storage as a independant base object
class TestObject {
  constructor() {
    this.testProp = 'testValue';
  }

  testProp: string;
}

describe('LocalStorageService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LocalStorageService]
    });
  });

  it('LSS001 -should be created', inject([LocalStorageService], (service: LocalStorageService) => {
    expect(service).toBeTruthy();
  }));

  it('LSS002 -should get item from storage', inject([LocalStorageService], (service: LocalStorageService) => {

    // arrange
    const objectToStore = new TestObject();
    const returnedObject: TestObject = undefined;

    localStorage.setItem('objectInStorage', JSON.stringify(objectToStore));
    // act
    const localStorageGetStream = service.get<TestObject>('objectInStorage')
                              .subscribe((obj: TestObject) => {
                                this.returnedObject = obj;
                              });

    // assert
    expect(this.returnedObject).toBeDefined();
    expect(this.returnedObject.testProp).toBeDefined();
    expect(this.returnedObject.testProp).toBe(objectToStore.testProp);
  }));

  it('LSS003 -should set item in storage', inject([LocalStorageService], (service: LocalStorageService) => {

        // arrange
        const isStored = false;
        const objectToStore = new TestObject();
        const returnedObject: TestObject = undefined;

        const localStorageSetStream = service.set<TestObject>('objectInStorage', objectToStore)
                                    .subscribe((s: boolean) => {
                                      this.isStored = s;
                                    });

        const localStorageGetStream = service.get<TestObject>('objectInStorage')
        .subscribe((obj: TestObject) => {
          this.returnedObject = obj;
        });

        // assert
        expect(this.isStored).toBeTruthy();
        expect(this.returnedObject).toBeDefined();
        expect(this.returnedObject.testProp).toBeDefined();
        expect(this.returnedObject.testProp).toBe(objectToStore.testProp);
      }));
});
