import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TravelsComponent } from './travels.component';

describe('UsersComponent', () => {
  let component: TravelsComponent;
  let fixture: ComponentFixture<TravelsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [TravelsComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TravelsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
