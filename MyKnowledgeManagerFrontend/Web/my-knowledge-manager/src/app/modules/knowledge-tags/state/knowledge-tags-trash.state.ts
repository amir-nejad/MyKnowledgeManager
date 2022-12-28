import { Injectable } from "@angular/core";
import { BehaviorSubject, filter } from "rxjs";
import { KnowledgeTag } from "src/app/shared";

@Injectable({
  providedIn: "root"
})
export class KnowledgeTagsTrashState {
  private updating$ = new BehaviorSubject<boolean>(false);
  private knowledgeTagsTrashItems$ = new BehaviorSubject<KnowledgeTag[]>([]);

  isUpdating$() {
    return this.updating$.asObservable();
  }

  setUpdating(isUpdating: boolean) {
    this.updating$.next(isUpdating);
  }

  getTrashKnowledgeTags$() {
    return this.knowledgeTagsTrashItems$.asObservable();
  }

  setTrashKnowledgeTags(knowledgeTagsTrashItems: KnowledgeTag[]) {
    this.knowledgeTagsTrashItems$.next(knowledgeTagsTrashItems);
  }

  addTrashKnowledgeTag(knowledgeTag: KnowledgeTag) {
    const knowledgeTagsTrashItems = this.knowledgeTagsTrashItems$.getValue();
    this.knowledgeTagsTrashItems$.next([...knowledgeTagsTrashItems, knowledgeTag]);
  }

  updateTrashKnowledgeTag(knowledgeTag: KnowledgeTag) {
    const knowledgeTagsTrashItems = this.knowledgeTagsTrashItems$.getValue();
    const indexOfUpdated = knowledgeTagsTrashItems.findIndex(tag => tag.id === knowledgeTag.id);

    knowledgeTagsTrashItems[indexOfUpdated] = knowledgeTag;
    this.knowledgeTagsTrashItems$.next([...knowledgeTagsTrashItems]);
  }

  removeTrashKnowledgeTag(id: string) {
    const knowledgeTagsTrashItems = this.knowledgeTagsTrashItems$.getValue();
    this.knowledgeTagsTrashItems$.next(knowledgeTagsTrashItems.filter(tag => tag.id !== id));
  }
}