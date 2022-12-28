import { Injectable } from '@angular/core';
import { KnowledgeTagsApi } from './api/knowledge-tags.api';
import { Observable, map, take, tap } from 'rxjs';
import { KnowledgeTag } from 'src/app/shared';
import { KnowledgeTagsTrashState } from './state/knowledge-tags-trash.state';
import { async } from '@angular/core/testing';

@Injectable({
  providedIn: 'root'
})
export class KnowledgeTagsTrashFacade {
  constructor(private _knowledgeTagsApi: KnowledgeTagsApi, private _knowledgeTagsTrashState: KnowledgeTagsTrashState) {

  }

  isUpdating$(): Observable<boolean> {
    return this._knowledgeTagsTrashState.isUpdating$();
  }

  getTrashKnowledgeTags$(): Observable<KnowledgeTag[]> {
    return this._knowledgeTagsTrashState.getTrashKnowledgeTags$();
  }

  async loadTrashKnowledgeTags() {
    this._knowledgeTagsTrashState.setUpdating(true);

    let result = await this._knowledgeTagsApi.getTrashKnowledgeTags$();

    result.subscribe(trashTags => {
      this._knowledgeTagsTrashState.setTrashKnowledgeTags(trashTags);
      this._knowledgeTagsTrashState.setUpdating(false);
    })
  }

  async getTrashKnowledgeTag$(id: string): Promise<Observable<KnowledgeTag>> {
    let knowledgeTag: KnowledgeTag = {
      id: "",
      tagName: "",
      isTrashItem: false,
      userId: "",
      createdDate: new Date(),
      updatedDate: new Date()
    };

    let result = await this._knowledgeTagsApi.getKnowledgeTag$(id);

    return result.pipe(map(tag => {
      console.log(tag);
      knowledgeTag = tag;
      console.log(knowledgeTag.createdDate);
      return knowledgeTag;
    }))
  }

  async restoreKnowledgeTag(id: string) {
    this._knowledgeTagsTrashState.setUpdating(true);
    let result = await this._knowledgeTagsApi.restoreKnowledgeTag$(id);

    result.subscribe(async result => {
      if (result == null) {
        await this.loadTrashKnowledgeTags();
      }
    })

    this._knowledgeTagsTrashState.setUpdating(false);
  }

  async deleteKnowledgeTag(id: string) {
    this._knowledgeTagsTrashState.setUpdating(true);
    let result = await this._knowledgeTagsApi.deleteKnowledgeTag$(id);

    result.subscribe(async result => {
      if (result == null) {
        await this.loadTrashKnowledgeTags();
      }
    })

    this._knowledgeTagsTrashState.setUpdating(false);
  }

  async EmptyTrash(id: string) {
    this._knowledgeTagsTrashState.setUpdating(true);
    let result = await this._knowledgeTagsApi.deleteKnowledgeTagTrashItems$();

    result.subscribe(async result => {
      if (result == null) {
        await this.loadTrashKnowledgeTags();
      }
    })
  }
}