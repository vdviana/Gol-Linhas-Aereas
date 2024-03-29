import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TravelDetailComponent } from './travel-detail.component';

describe('UserDetailComponent', () => {
  let component: TravelDetailComponent;
  let fixture: ComponentFixture<TravelDetailComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [TravelDetailComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TravelDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
