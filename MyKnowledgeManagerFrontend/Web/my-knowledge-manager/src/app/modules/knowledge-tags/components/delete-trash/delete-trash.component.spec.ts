import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DeleteTrashComponent } from './delete-trash.component';

describe('DeleteTrashComponent', () => {
  let component: DeleteTrashComponent;
  let fixture: ComponentFixture<DeleteTrashComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DeleteTrashComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DeleteTrashComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
