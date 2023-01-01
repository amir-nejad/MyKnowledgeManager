import { Injectable } from "@angular/core";
import { BehaviorSubject, filter } from "rxjs";
import { Knowledge } from "src/app/shared";

@Injectable({
  providedIn: "root"
})
export class KnowledgeState {
  private updating$ = new BehaviorSubject<boolean>(false);
  private knowledge$ = new BehaviorSubject<Knowledge[]>([]);

  isUpdating$() {
    return this.updating$.asObservable();
  }

  setUpdating(isUpdating: boolean) {
    this.updating$.next(isUpdating);
  }

  getKnowledge$() {
    return this.knowledge$.asObservable();
  }

  setKnowledge(knowledgeList: Knowledge[]) {
    this.knowledge$.next(knowledgeList);
  }

  addKnowledge(knowledge: Knowledge) {
    const knowledgeList = this.knowledge$.getValue();
    this.knowledge$.next([...knowledgeList, knowledge]);
  }

  updateKnowledge(knowledge: Knowledge) {
    const knowledgeList = this.knowledge$.getValue();
    const indexOfUpdated = knowledgeList.findIndex(knowledge => knowledge.id === knowledge.id);

    knowledgeList[indexOfUpdated] = knowledge;
    this.knowledge$.next([...knowledgeList]);
  }

  removeKnowledge(id: string) {
    const knowledge = this.knowledge$.getValue();
    this.knowledge$.next(knowledge.filter(tag => tag.id !== id));
  }
}