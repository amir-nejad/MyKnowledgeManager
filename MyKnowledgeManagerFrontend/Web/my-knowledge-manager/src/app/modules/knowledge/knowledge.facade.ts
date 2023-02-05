import { Injectable } from '@angular/core';
import { Observable, map, take, tap } from 'rxjs';
import { Knowledge, KnowledgeImportance, KnowledgeLevel } from 'src/app/shared';
import { KnowledgeApi } from './api/knowledge.api.service';
import { KnowledgeState } from './state/knowledge.state';


@Injectable({
  providedIn: 'root'
})
export class KnowledgeFacade {
  constructor(private _knowledgeApi: KnowledgeApi, private _knowledgeState: KnowledgeState) {

  }

  isUpdating$(): Observable<boolean> {
    return this._knowledgeState.isUpdating$();
  }

  getKnowledgeList$(): Observable<Knowledge[]> {
    return this._knowledgeState.getKnowledge$();
  }

  async loadKnowledge() {
    this._knowledgeState.setUpdating(true);

    let result = await this._knowledgeApi.getKnowledgeList$();
    result.subscribe(tags => {
      this._knowledgeState.setKnowledge(tags);
      this._knowledgeState.setUpdating(false);
    });
  }

  async getKnowledge$(id: string, includeTags: boolean = false): Promise<Observable<Knowledge>> {
    let knowledge: Knowledge = {
      id: "",
      title: "",
      description: "",
      knowledgeImportance: KnowledgeImportance.Neutral,
      knowledgeLevel: KnowledgeLevel.Beginner,
      knowledgeTags: [],
      isTrashItem: false,
      userId: "",
      createdDate: new Date(),
      updatedDate: new Date()
    };

    let result = await this._knowledgeApi.getKnowledge$(id, includeTags);

    return result.pipe(map(tag => {
      console.log(tag);
      knowledge = tag;
      console.log(knowledge.createdDate);
      return knowledge;
    }))
  }

  async addKnowledge(knowledge: Knowledge): Promise<Knowledge> {
    this._knowledgeState.setUpdating(true);
    let result = await this._knowledgeApi.createKnowledge$(knowledge);

    result.subscribe((addedTagWithId: Knowledge) => {
      this._knowledgeState.addKnowledge(addedTagWithId);
      knowledge = addedTagWithId;
    }),
      (error: any) => {
        this._knowledgeState.removeKnowledge(knowledge.id!);
        console.log(error);
        knowledge.id = "";
      }

      this._knowledgeState.setUpdating(false);

      return knowledge;
  }

  async updateKnowledge(knowledge: Knowledge): Promise<Knowledge> {
    this._knowledgeState.setUpdating(true);
    let result = await this._knowledgeApi.updateKnowledge$(knowledge);

    result.subscribe((updatedKnowledgeWithId: Knowledge) => {
      this._knowledgeState.updateKnowledge(updatedKnowledgeWithId);
      knowledge = updatedKnowledgeWithId;
    }),
      (error: any) => {
        console.log(error);
      }

      this._knowledgeState.setUpdating(false);

      return knowledge;
  }

  async moveToTrashKnowledge(id: string) {
    this._knowledgeState.setUpdating(true);
    let result = await this._knowledgeApi.moveToTrashKnowledge$(id);

    result.subscribe(result => {
      if(result == null) {
        this._knowledgeState.removeKnowledge(id);
      }
    })

    this._knowledgeState.setUpdating(false);
  }
}