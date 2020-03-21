import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthProjectComponent } from './health-project.component';

describe('HealthProjectComponent', () => {
  let component: HealthProjectComponent;
  let fixture: ComponentFixture<HealthProjectComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HealthProjectComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthProjectComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
