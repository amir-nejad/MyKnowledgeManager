import { Component, Input, OnInit } from '@angular/core';
import { Knowledge } from '../../../../shared/models/knowledge';
import { KnowledgeImportance, KnowledgeLevel } from 'src/app/shared';
import { KnowledgeFacade } from '../../knowledge.facade';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import * as tagify from 'ngx-tagify';
import { KnowledgeTagsFacade } from '../../../knowledge-tags/knowledge-tags.facade';
import { BehaviorSubject, map, mergeMap, of } from 'rxjs';
import { KnowledgeTag } from '../../../../shared/models/knowledge-tag';

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

  knowledgeImportanceArray: string[] = [
    KnowledgeImportance.Neutral.toString(),
    KnowledgeImportance.Important.toString(),
    KnowledgeImportance.VeryImportant.toString()
  ]

  knowledgeLevelArray: string[] = [
    KnowledgeLevel.Beginner.toString(),
    KnowledgeLevel.Intermediate.toString(),
    KnowledgeLevel.Advanced.toString(),
    KnowledgeLevel.Expert.toString()
  ]

  tags: tagify.TagData[] = [];

  tagifySettings: tagify.TagifySettings = {
    placeholder: "Start typing...",
    duplicates: false,
    readonly: false,
  }

  whitelist$ = new BehaviorSubject<string[]>([]);

  constructor(private _knowledgeFacade: KnowledgeFacade,
    private _activeModals: NgbModal) {
  }

  ngOnInit(): void {
    this._knowledgeFacade.isUpdating$().subscribe(isUpdating => {
      this.isUpdating = isUpdating;
    });
  }



  async createKnowledge() {
    // Assigning KnowledgeImportance and KnowledgeLevel for the API request.
    this.knowledge.knowledgeImportance = Number.parseInt(this.knowledge.knowledgeImportance.toString());
    this.knowledge.knowledgeLevel = Number.parseInt(this.knowledge.knowledgeLevel.toString());

    // Assigning user entered tags
    this.knowledge.knowledgeTags = this.tags.map(item => item.value);

    Promise.all([await this._knowledgeFacade.addKnowledge(this.knowledge)]);
    if (this._activeModals.hasOpenModals()) {
      this._activeModals.dismissAll();
    }
  }

  async updateKnowledge() {
    // Assigning KnowledgeImportance and KnowledgeLevel for the API request.
    this.knowledge.knowledgeImportance = Number.parseInt(this.knowledge.knowledgeImportance.toString());
    this.knowledge.knowledgeLevel = Number.parseInt(this.knowledge.knowledgeLevel.toString());

    // Assigning user entered tags
    this.knowledge.knowledgeTags = this.tags.map(item => item.value);

    Promise.all([await this._knowledgeFacade.updateKnowledge(this.knowledge)]);
    if (this._activeModals.hasOpenModals()) {
      this._activeModals.dismissAll();
    }
  }
}
