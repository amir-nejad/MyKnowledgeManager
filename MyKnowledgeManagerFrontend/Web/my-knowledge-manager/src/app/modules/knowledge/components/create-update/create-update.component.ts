import { Component, Input, OnInit } from '@angular/core';
import { Knowledge } from '../../../../shared/models/knowledge';
import { KnowledgeImportance, KnowledgeLevel } from 'src/app/shared';
import { KnowledgeFacade } from '../../knowledge.facade';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';

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
    KnowledgeImportance.NotImportant.toString(),
    KnowledgeImportance.VeryImportant.toString()
  ]

  knowledgeLevelArray: string[] = [
    KnowledgeLevel.Beginner.toString(),
    KnowledgeLevel.Intermediate.toString(),
    KnowledgeLevel.Advanced.toString(),
    KnowledgeLevel.Expert.toString()
  ]

  constructor(private _knowledgeFacade: KnowledgeFacade,
              private _activeModals: NgbModal) {
   }

   ngOnInit(): void {
    this._knowledgeFacade.isUpdating$().subscribe(isUpdating => {
      this.isUpdating = isUpdating;
    })
  }

  async createKnowledge() {
    console.log(this.knowledge);
    Promise.all([await this._knowledgeFacade.addKnowledge(this.knowledge)]);
    if (this._activeModals.hasOpenModals()) {
      this._activeModals.dismissAll();
    }
  }

  async updateKnowledge() {
    console.log("Update Called.");
    Promise.all([await this._knowledgeFacade.updateKnowledge(this.knowledge)]);
    if (this._activeModals.hasOpenModals()) {
      this._activeModals.dismissAll();
    }
  }
}
