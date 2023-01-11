import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { KnowledgeFacade } from '../../knowledge.facade';
import { Knowledge } from '../../../../shared/models/knowledge';

@Component({
  selector: 'app-knowledge-list',
  templateUrl: './knowledge-list.component.html',
  styleUrls: ['./knowledge-list.component.scss']
})
export class KnowledgeListComponent implements OnInit {

  isUpdating: boolean = false;
  knowledgeList: Knowledge[] = [];
  @Input() trashMode: boolean = false;
  @Output() editButtonClicked = new EventEmitter<void>();
  @Output() moveToTrashButtonClicked = new EventEmitter<void>();
  @Output() deleteButtonClicked = new EventEmitter<void>();
  @Output() restoreButtonClicked = new EventEmitter<void>();

  constructor(private _knowledgeFacade: KnowledgeFacade) {
  }

  async ngOnInit(): Promise<void> {
    if (this.trashMode) {

    } else {
      this._knowledgeFacade.isUpdating$().subscribe(isUpdating => {
        this.isUpdating = isUpdating;
      });

      this._knowledgeFacade.getKnowledgeList$().subscribe(knowledgeList => {
        this.knowledgeList = knowledgeList;
      });

      await this._knowledgeFacade.loadKnowledge();
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
