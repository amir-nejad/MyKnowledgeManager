import { Component, Input, OnInit } from '@angular/core';
import { Knowledge, KnowledgeImportance, KnowledgeLevel } from 'src/app/shared';
import { KnowledgeFacade } from '../../knowledge.facade';
import { KnowledgeTrashFacade } from '../../knowledge.trash.facade';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-delete-trash',
  templateUrl: './delete-trash.component.html',
  styleUrls: ['./delete-trash.component.scss']
})
export class DeleteTrashComponent implements OnInit {
  @Input() trashMode: boolean = false;
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

  constructor(private _knowledgeFacade: KnowledgeFacade,
    private _knowledgeTrashFacade: KnowledgeTrashFacade,
    private _activeModals: NgbModal) {
  }

  ngOnInit(): void {
  }

  async moveToTrash() {
    await this._knowledgeFacade.moveToTrashKnowledge(this.knowledge.id!);

    if(this._activeModals.hasOpenModals()) {
      this._activeModals.dismissAll();
    }
  }

  async deleteItem() {
    await this._knowledgeTrashFacade.deleteKnowledge(this.knowledge.id!);

    if(this._activeModals.hasOpenModals()) {
      this._activeModals.dismissAll();
    }
  }
}
