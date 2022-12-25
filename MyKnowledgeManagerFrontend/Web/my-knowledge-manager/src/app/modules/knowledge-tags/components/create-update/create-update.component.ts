import { Component, ElementRef, Input, OnInit, ViewChild } from '@angular/core';
import { KnowledgeTag } from '../../../../shared/models/knowledge-tag';
import { KnowledgeTagsFacade } from '../../knowledge-tags.facade';
import { Observable, delay } from 'rxjs';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap'

@Component({
  selector: 'app-create-update',
  templateUrl: './create-update.component.html',
  styleUrls: ['./create-update.component.scss']
})
export class CreateUpdateComponent implements OnInit {
  @Input() knowledgeTag: KnowledgeTag = {
    id: crypto.randomUUID(),
    tagName: "",
    createdDate: new Date(),
    updatedDate: new Date(),
    isTrashItem: false,
    userId: ""
  };

  @Input() updateMode: boolean = false;

  isUpdating: boolean | undefined;

  constructor(private _knowledgeTagsFacade: KnowledgeTagsFacade, private _activeModals: NgbModal) {
  }

  ngOnInit(): void {
    this._knowledgeTagsFacade.isUpdating$().subscribe(isUpdating => {
      this.isUpdating = isUpdating;
    })
  }

  async createKnowledgeTag() {
    Promise.all([await this._knowledgeTagsFacade.addKnowledgeTag(this.knowledgeTag)]);
    if (this._activeModals.hasOpenModals()) {
      this._activeModals.dismissAll();
    }
  }
}
