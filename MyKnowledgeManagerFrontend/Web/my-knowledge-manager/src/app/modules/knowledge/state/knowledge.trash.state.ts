import { Injectable } from "@angular/core";
import { BehaviorSubject } from "rxjs";
import { Knowledge } from "src/app/shared";

@Injectable({
  providedIn: "root"
})
export class KnowledgeTrashState {
  private updating$ = new BehaviorSubject<boolean>(false);
  private knowledgeTrashItems$ = new BehaviorSubject<Knowledge[]>([]);

  isUpdating$() {
    return this.updating$.asObservable();
  }

  setUpdating(isUpdating: boolean) {
    this.updating$.next(isUpdating);
  }

  getTrashKnowledge$() {
    return this.knowledgeTrashItems$.asObservable();
  }

  setTrashKnowledge(knowledgeTrashItems: Knowledge[]) {
    this.knowledgeTrashItems$.next(knowledgeTrashItems);
  }

  addTrashKnowledge(knowledge: Knowledge) {
    const knowledgeTrashItems = this.knowledgeTrashItems$.getValue();
    this.knowledgeTrashItems$.next([...knowledgeTrashItems, knowledge]);
  }

  updateTrashKnowledge(knowledge: Knowledge) {
    const knowledgeTrashItems = this.knowledgeTrashItems$.getValue();
    const indexOfUpdated = knowledgeTrashItems.findIndex(tag => tag.id === knowledge.id);

    knowledgeTrashItems[indexOfUpdated] = knowledge;
    this.knowledgeTrashItems$.next([...knowledgeTrashItems]);
  }

  removeTrashKnowledge(id: string) {
    const knowledgeTrashItems = this.knowledgeTrashItems$.getValue();
    this.knowledgeTrashItems$.next(knowledgeTrashItems.filter(tag => tag.id !== id));
  }
}