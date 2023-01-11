import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { KnowledgeTagsFacade } from '../../knowledge-tags.facade';
import { KnowledgeTag } from 'src/app/shared';
import { KnowledgeTagsTrashFacade } from '../../knowledge-tags-trash.facade';

@Component({
  selector: 'app-tags-list',
  templateUrl: './tags-list.component.html',
  styleUrls: ['./tags-list.component.scss']
})
export class TagsListComponent implements OnInit {

  isUpdating: boolean = false;
  knowledgeTags: KnowledgeTag[] = [];
  @Input() trashMode: boolean = false;
  @Output() editButtonClicked = new EventEmitter<void>();
  @Output() moveToTrashButtonClicked = new EventEmitter<void>();
  @Output() deleteButtonClicked = new EventEmitter<void>();
  @Output() restoreButtonClicked = new EventEmitter<void>();

  constructor(private _knowledgeTagsFacade: KnowledgeTagsFacade,
    private _knowledgeTagsTrashFacade: KnowledgeTagsTrashFacade) {
  }

  async ngOnInit(): Promise<void> {
    if (this.trashMode) {
      this._knowledgeTagsTrashFacade.isUpdating$().subscribe(isUpdating => {
        this.isUpdating = isUpdating;
      });

      this._knowledgeTagsTrashFacade.getTrashKnowledgeTags$().subscribe(tags => {
        this.knowledgeTags = tags;
      });

      await this._knowledgeTagsTrashFacade.loadTrashKnowledgeTags();
    } else {
      this._knowledgeTagsFacade.isUpdating$().subscribe(isUpdating => {
        this.isUpdating = isUpdating;
      });

      this._knowledgeTagsFacade.getKnowledgeTags$().subscribe(tags => {
        this.knowledgeTags = tags;
      });

      await this._knowledgeTagsFacade.loadKnowledgeTags();
    }
  }

  editClicked(id: string) {
    this.setItemIdInput(id);
    this.editButtonClicked.emit();
  }

  moveToTrashClicked(id: string) {
    this.setItemIdInput(id);
    this.moveToTrashButtonClicked.emit();
  }

  deleteClicked(id: string) {
    this.setItemIdInput(id);
    this.deleteButtonClicked.emit();
  }

  restoreClicked(id: string) {
    this.setItemIdInput(id);
    this.restoreButtonClicked.emit();
  }

  private setItemIdInput(value: string) {
    let itemIdInput: HTMLInputElement = document.getElementById("itemId") as HTMLInputElement;
    itemIdInput.value = value;
  }
}
