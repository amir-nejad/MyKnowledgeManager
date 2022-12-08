import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateKnowledgeTagComponent } from './create-knowledge-tag.component';

describe('CreateKnowledgeTagComponent', () => {
  let component: CreateKnowledgeTagComponent;
  let fixture: ComponentFixture<CreateKnowledgeTagComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CreateKnowledgeTagComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateKnowledgeTagComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
