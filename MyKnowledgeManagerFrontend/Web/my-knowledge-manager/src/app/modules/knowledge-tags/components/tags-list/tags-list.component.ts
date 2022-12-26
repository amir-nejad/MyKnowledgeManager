import { Component, EventEmitter, OnInit, Output } from '@angular/core';
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
  @Output() editButtonClicked = new EventEmitter<void>();
  @Output() deleteButtonClicked = new EventEmitter<void>();

  constructor(private _knowledgeTagsFacade: KnowledgeTagsFacade) {
   }

  async ngOnInit(): Promise<void> {
    this._knowledgeTagsFacade.isUpdating$().subscribe(isUpdating => {
      this.isUpdating = isUpdating;
    });

    this._knowledgeTagsFacade.getKnowledgeTags$().subscribe(tags => {
      this.knowledgeTags = tags;
    });

    await this._knowledgeTagsFacade.loadKnowledgeTags();
  }

  editClicked(id: string) {
    let updateItemIdInput: HTMLInputElement = document.getElementById("updateItemId") as HTMLInputElement;
    updateItemIdInput.value = id;
    this.editButtonClicked.emit();
  }

  deleteClicked(id: string) {
    console.log(id);
    let updateItemIdInput: HTMLInputElement = document.getElementById("updateItemId") as HTMLInputElement;
    updateItemIdInput.value = id;
    this.deleteButtonClicked.emit();
  }
}
