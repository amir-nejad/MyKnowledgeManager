import { Component, Input, OnInit } from '@angular/core';
import { KnowledgeTag } from '../../../../shared/models/knowledge-tag';
import { KnowledgeTagsFacade } from '../../knowledge-tags.facade';

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

  constructor(private _knowledgeTagsFacade: KnowledgeTagsFacade) { }

  ngOnInit(): void {
  }

  async createKnowledgeTag() {
    await this._knowledgeTagsFacade.addKnowledgeTag(this.knowledgeTag);
  }
}
