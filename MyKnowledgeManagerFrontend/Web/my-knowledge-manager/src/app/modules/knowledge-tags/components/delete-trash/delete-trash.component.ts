import { Component, Input, OnInit } from '@angular/core';
import { KnowledgeTag } from '../../../../shared/models/knowledge-tag';
import { KnowledgeTagsFacade } from '../../knowledge-tags.facade';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-delete-trash',
  templateUrl: './delete-trash.component.html',
  styleUrls: ['./delete-trash.component.scss']
})
export class DeleteTrashComponent implements OnInit {
  @Input() trashMode: boolean = false;
  @Input() knowledgeTag: KnowledgeTag = {
    id: crypto.randomUUID(),
    tagName: "",
    createdDate: new Date(),
    updatedDate: new Date(),
    isTrashItem: false,
    userId: ""
  };

  constructor(private _knowledgeTagsFacade: KnowledgeTagsFacade, private _activeModals: NgbModal) {
  }

  ngOnInit(): void {
  }

  async moveToTrash() {
    await this._knowledgeTagsFacade.moveToTrashKnowledgeTag(this.knowledgeTag.id!);

    if(this._activeModals.hasOpenModals()) {
      this._activeModals.dismissAll();
    }
  }
}
