import { Injectable } from '@angular/core';
import { KnowledgeTagsApi } from './api/knowledge-tags.api';
import { KnowledgeTagsState } from './state/knowledge-tags.state';
import { Observable, tap } from 'rxjs';
import { KnowledgeTag } from 'src/app/shared';

@Injectable({
  providedIn: 'root'
})
export class KnowledgeTagsFacade {
  constructor(private _knowledgeTagsApi: KnowledgeTagsApi, private _knowledgeTagsState: KnowledgeTagsState) {

  }

  isUpdating$(): Observable<boolean> {
    return this._knowledgeTagsState.isUpdating$();
  }

  getKnowledgeTags$(): Observable<KnowledgeTag[]> {
    return this._knowledgeTagsState.getKnowledgeTags$();
  }

  async loadKnowledgeTags() {
    let result = await this._knowledgeTagsApi.getKnowledgeTags$();
    result.pipe(tap(tags => this._knowledgeTagsState.setKnowledgeTags(tags)))
  }

  async addKnowledgeTag(knowledgeTag: KnowledgeTag): Promise<KnowledgeTag> {
    this._knowledgeTagsState.setUpdating(true);
    let result = await this._knowledgeTagsApi.createKnowledgeTag$(knowledgeTag);

    result.subscribe((addedTagWithId: KnowledgeTag) => {
      this._knowledgeTagsState.addKnowledgeTag(addedTagWithId);
      console.log(addedTagWithId);
      knowledgeTag = addedTagWithId;
    }),
      (error: any) => {
        this._knowledgeTagsState.removeKnowledgeTag(knowledgeTag);
        console.log(error);
        knowledgeTag.id = "";
      }

      this._knowledgeTagsState.setUpdating(false);

      return knowledgeTag;
  }
}