import { Injectable } from "@angular/core";
import { BehaviorSubject, filter } from "rxjs";
import { KnowledgeTagDTO } from '../../../shared/models/knowledge-tag-dto';

@Injectable()
export class KnowledgeTagsState {
  private updating$ = new BehaviorSubject<boolean>(false);
  private knowledgeTagDTOs$ = new BehaviorSubject<KnowledgeTagDTO[]>([]);

  isUpdating$() {
    return this.updating$.asObservable();
  }

  setUpdating(isUpdating: boolean) {
    this.updating$.next(isUpdating);
  }

  getKnowledgeTagDTOs$(){
    return this.knowledgeTagDTOs$.asObservable();
  }

  setKnowledgeTagDTOs(knowledgeTagDTOs: KnowledgeTagDTO[]) {
    this.knowledgeTagDTOs$.next(knowledgeTagDTOs);
  }

  addKnowledgeTagDTO(knowledgeTagDTO: KnowledgeTagDTO){
    const knowledgeTagDTOs = this.knowledgeTagDTOs$.getValue();
    this.knowledgeTagDTOs$.next([...knowledgeTagDTOs, knowledgeTagDTO]);
  }

  updateKnowledgeTagDTO(knowledgeTagDTO: KnowledgeTagDTO) {
    const knowledgeTagDTOs = this.knowledgeTagDTOs$.getValue();
    const indexOfUpdated = knowledgeTagDTOs.findIndex(tag => tag.id === knowledgeTagDTO.id);

    knowledgeTagDTOs[indexOfUpdated] = knowledgeTagDTO;
    this.knowledgeTagDTOs$.next([...knowledgeTagDTOs]);
  }

  removeKnowledgeTagDTO(knowledgeTagDTO: KnowledgeTagDTO) {
    const knowledgeTagDTOs = this.knowledgeTagDTOs$.getValue();
    this.knowledgeTagDTOs$.next(knowledgeTagDTOs.filter(tag => tag.id !== knowledgeTagDTO.id));
  }
}