import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewKnowledgeComponent } from './view-knowledge.component';

describe('ViewKnowledgeComponent', () => {
  let component: ViewKnowledgeComponent;
  let fixture: ComponentFixture<ViewKnowledgeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewKnowledgeComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ViewKnowledgeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
