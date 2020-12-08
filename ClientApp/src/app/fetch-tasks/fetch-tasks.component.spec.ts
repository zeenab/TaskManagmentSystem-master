import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FetchTasksComponent } from './fetch-tasks.component';

describe('FetchTasksComponent', () => {
  let component: FetchTasksComponent;
  let fixture: ComponentFixture<FetchTasksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FetchTasksComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FetchTasksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
