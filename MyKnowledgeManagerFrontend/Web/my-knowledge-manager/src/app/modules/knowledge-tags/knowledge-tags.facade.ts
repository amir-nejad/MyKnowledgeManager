import { Injectable } from '@angular/core';
import { KnowledgeTagsApi } from './api/knowledge-tags.api';
import { KnowledgeTagsState } from './state/knowledge-tags.state';
import { Observable, map, take, tap } from 'rxjs';
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
    this._knowledgeTagsState.setUpdating(true);

    let result = await this._knowledgeTagsApi.getKnowledgeTags$();
    result.subscribe(tags => {
      this._knowledgeTagsState.setKnowledgeTags(tags);
      this._knowledgeTagsState.setUpdating(false);
    });
  }

  async getKnowledgeTag$(id: string): Promise<Observable<KnowledgeTag>> {
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

  async addKnowledgeTag(knowledgeTag: KnowledgeTag): Promise<KnowledgeTag> {
    this._knowledgeTagsState.setUpdating(true);
    let result = await this._knowledgeTagsApi.createKnowledgeTag$(knowledgeTag);

    result.subscribe((addedTagWithId: KnowledgeTag) => {
      this._knowledgeTagsState.addKnowledgeTag(addedTagWithId);
      knowledgeTag = addedTagWithId;
    }),
      (error: any) => {
        this._knowledgeTagsState.removeKnowledgeTag(knowledgeTag.id!);
        console.log(error);
        knowledgeTag.id = "";
      }

      this._knowledgeTagsState.setUpdating(false);

      return knowledgeTag;
  }

  async updateKnowledgeTag(knowledgeTag: KnowledgeTag): Promise<KnowledgeTag> {
    this._knowledgeTagsState.setUpdating(true);
    let result = await this._knowledgeTagsApi.updateKnowledgeTag$(knowledgeTag);

    result.subscribe((updatedTagWithId: KnowledgeTag) => {
      this._knowledgeTagsState.updateKnowledgeTag(updatedTagWithId);
      knowledgeTag = updatedTagWithId;
    }),
      (error: any) => {
        console.log(error);
      }

      this._knowledgeTagsState.setUpdating(false);

      return knowledgeTag;
  }

  async moveToTrashKnowledgeTag(id: string) {
    this._knowledgeTagsState.setUpdating(true);
    let result = await this._knowledgeTagsApi.moveToTrashKnowledgeTag$(id);

    result.subscribe(result => {
      if(result == null) {
        this._knowledgeTagsState.removeKnowledgeTag(id);
      }
    })

    this._knowledgeTagsState.setUpdating(false);
  }
}