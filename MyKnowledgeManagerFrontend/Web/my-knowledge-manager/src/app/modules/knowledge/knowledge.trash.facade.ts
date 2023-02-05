import { Injectable } from '@angular/core';
import { Observable, map, take, tap } from 'rxjs';
import { Knowledge, KnowledgeImportance, KnowledgeLevel } from 'src/app/shared';
import { KnowledgeApi } from './api/knowledge.api.service';
import { KnowledgeTrashState } from './state/knowledge.trash.state';

@Injectable({
  providedIn: 'root'
})
export class KnowledgeTrashFacade {
  constructor(private _knowledgeApi: KnowledgeApi, private _knowledgeTrashState: KnowledgeTrashState) {

  }

  isUpdating$(): Observable<boolean> {
    return this._knowledgeTrashState.isUpdating$();
  }

  getTrashKnowledgeList$(): Observable<Knowledge[]> {
    return this._knowledgeTrashState.getTrashKnowledge$();
  }

  async loadTrashKnowledgeList() {
    this._knowledgeTrashState.setUpdating(true);

    let result = await this._knowledgeApi.getTrashKnowledge$();

    result.subscribe(trashTags => {
      this._knowledgeTrashState.setTrashKnowledge(trashTags);
      this._knowledgeTrashState.setUpdating(false);
    })
  }

  async getTrashKnowledge$(id: string): Promise<Observable<Knowledge>> {
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

    let result = await this._knowledgeApi.getKnowledge$(id);

    return result.pipe(map(result => {
      knowledge = result;
      return knowledge;
    }))
  }

  async restoreKnowledge(id: string) {
    this._knowledgeTrashState.setUpdating(true);
    let result = await this._knowledgeApi.restoreKnowledge$(id);

    result.subscribe(async result => {
      if (result == null) {
        await this.loadTrashKnowledgeList();
      }
    })

    this._knowledgeTrashState.setUpdating(false);
  }

  async deleteKnowledge(id: string) {
    this._knowledgeTrashState.setUpdating(true);
    let result = await this._knowledgeApi.deleteKnowledge$(id);

    result.subscribe(async result => {
      if (result == null) {
        await this.loadTrashKnowledgeList();
      }
    })

    this._knowledgeTrashState.setUpdating(false);
  }

  async emptyTrash() {
    this._knowledgeTrashState.setUpdating(true);
    let result = await this._knowledgeApi.deleteKnowledgeTrashItems$();

    result.subscribe(async result => {
      console.log(result);
      if (result == null) {
        await this.loadTrashKnowledgeList();
      }
    }, (error: any) => {
      console.log(error);
    })

    this._knowledgeTrashState.setUpdating(false);
  }
}