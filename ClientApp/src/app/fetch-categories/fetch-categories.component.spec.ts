import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FetchCategoriesComponent } from './fetch-categories.component';

describe('FetchCategoriesComponent', () => {
  let component: FetchCategoriesComponent;
  let fixture: ComponentFixture<FetchCategoriesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FetchCategoriesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FetchCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
