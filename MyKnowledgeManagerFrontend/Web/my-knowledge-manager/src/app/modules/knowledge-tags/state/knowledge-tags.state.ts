import { Injectable } from "@angular/core";
import { BehaviorSubject, filter } from "rxjs";
import { KnowledgeTag } from "src/app/shared";

@Injectable({
  providedIn: "root"
})
export class KnowledgeTagsState {
  private updating$ = new BehaviorSubject<boolean>(false);
  private knowledgeTags$ = new BehaviorSubject<KnowledgeTag[]>([]);

  isUpdating$() {
    return this.updating$.asObservable();
  }

  setUpdating(isUpdating: boolean) {
    this.updating$.next(isUpdating);
  }

  getKnowledgeTags$() {
    return this.knowledgeTags$.asObservable();
  }

  setKnowledgeTags(knowledgeTags: KnowledgeTag[]) {
    this.knowledgeTags$.next(knowledgeTags);
  }

  addKnowledgeTag(knowledgeTag: KnowledgeTag) {
    const knowledgeTags = this.knowledgeTags$.getValue();
    this.knowledgeTags$.next([...knowledgeTags, knowledgeTag]);
  }

  updateKnowledgeTag(knowledgeTag: KnowledgeTag) {
    const knowledgeTags = this.knowledgeTags$.getValue();
    const indexOfUpdated = knowledgeTags.findIndex(tag => tag.id === knowledgeTag.id);

    knowledgeTags[indexOfUpdated] = knowledgeTag;
    this.knowledgeTags$.next([...knowledgeTags]);
  }

  removeKnowledgeTag(id: string) {
    const knowledgeTags = this.knowledgeTags$.getValue();
    this.knowledgeTags$.next(knowledgeTags.filter(tag => tag.id !== id));
  }
}