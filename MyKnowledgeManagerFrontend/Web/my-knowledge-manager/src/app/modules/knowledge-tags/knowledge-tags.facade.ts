import { Injectable } from '@angular/core';
import { KnowledgeTagsApi } from './api/knowledge-tags.api';
import { KnowledgeTagsState } from './state/knowledge-tags.state';
import { Observable, tap } from 'rxjs';
import { KnowledgeTagDTO } from 'src/app/shared';

@Injectable({
    providedIn: 'root'
})
export class KnowledgeTagsFacade {
    constructor(private _knowledgeTagsApi: KnowledgeTagsApi, private _knowledgeTagsState: KnowledgeTagsState) {

    }

    isUpdating$(): Observable<boolean> {
        return this._knowledgeTagsState.isUpdating$();
    }

    getKnowledgeTags$(): Observable<KnowledgeTagDTO[]> {
        return this._knowledgeTagsState.getKnowledgeTagDTOs$();
    }

    // loadKnowledgeTags() {
    //     this._knowledgeTagsApi.getKnowledgeTags$()
    //     .pipe(tap(tags => this._knowledgeTagsState.setKnowledgeTagDTOs(tags)));
    // }

    // addKnowledgeTag(knowledgeTagDTO: KnowledgeTagDTO) {
    //     this._knowledgeTagsState.addKnowledgeTagDTO(knowledgeTagDTO);
    //     this._knowledgeTagsApi.createKnowledgeTag$(knowledgeTagDTO)
    //         .subscribe((addedTagWithId: KnowledgeTagDTO) => {
    //             this._knowledgeTagsState.updateKnowledgeTagDTO(addedTagWithId);

    //         }),
    //         (error: any) => {
    //             this._knowledgeTagsState.removeKnowledgeTagDTO(knowledgeTagDTO);
    //             console.log(error);
    //         }
    // }
}