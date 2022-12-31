import { Component, Input, OnInit } from '@angular/core';
import { Knowledge } from '../../../../shared/models/knowledge';
import { KnowledgeImportance, KnowledgeLevel } from 'src/app/shared';
import { KnowledgeFacade } from '../../knowledge.facade';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-create-update',
  templateUrl: './create-update.component.html',
  styleUrls: ['./create-update.component.scss']
})
export class CreateUpdateComponent implements OnInit {
  @Input() knowledge: Knowledge = {
    id: crypto.randomUUID(),
    title: "",
    description: "",
    knowledgeImportance: KnowledgeImportance.Neutral,
    knowledgeLevel: KnowledgeLevel.Beginner,
    knowledgeTags: [],
    createdDate: new Date(),
    updatedDate: new Date(),
    isTrashItem: false,
    userId: ""
  };

  @Input() updateMode: boolean = false;

  isUpdating: boolean | undefined;


  constructor(private _knowledgeFacade: KnowledgeFacade, private _activeModals: NgbModal) { }

  ngOnInit(): void {
  }

  createKnowledge() {

  }

  updateKnowledge() {

  }
}
