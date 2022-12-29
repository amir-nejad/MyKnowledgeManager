import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KnowledgesListComponent } from './knowledges-list.component';

describe('KnowledgesListComponent', () => {
  let component: KnowledgesListComponent;
  let fixture: ComponentFixture<KnowledgesListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ KnowledgesListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(KnowledgesListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
