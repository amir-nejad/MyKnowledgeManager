import { Component, OnInit } from '@angular/core';
import { KnowledgeTagsFacade } from '../../knowledge-tags.facade';
import { Observable } from 'rxjs';
import { KnowledgeTag } from 'src/app/shared';

@Component({
  selector: 'app-tags-list',
  templateUrl: './tags-list.component.html',
  styleUrls: ['./tags-list.component.scss']
})
export class TagsListComponent implements OnInit {

  isUpdating: boolean = false;
  knowledgeTags: KnowledgeTag[] = [];

  constructor(private _knowledgeTagsFacade: KnowledgeTagsFacade) {
   }

  async ngOnInit(): Promise<void> {
    this._knowledgeTagsFacade.isUpdating$().subscribe(isUpdating => {
      this.isUpdating = isUpdating;
    })

    this._knowledgeTagsFacade.getKnowledgeTags$().subscribe(tags => {
      this.knowledgeTags = tags;
    })

    await this._knowledgeTagsFacade.loadKnowledgeTags();
  }

}
