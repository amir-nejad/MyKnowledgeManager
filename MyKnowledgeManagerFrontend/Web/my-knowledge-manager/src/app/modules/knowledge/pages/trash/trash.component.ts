import { Component, OnInit } from '@angular/core';
import { Knowledge, KnowledgeImportance, KnowledgeLevel } from 'src/app/shared';
import { KnowledgeTrashFacade } from '../../knowledge.trash.facade';
import { KnowledgeFacade } from '../../knowledge.facade';
import { AuthService } from 'src/app/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-trash',
  templateUrl: './trash.component.html',
  styleUrls: ['./trash.component.scss']
})
export class TrashComponent implements OnInit {

  isUpdating: boolean = false;
  knowledge: Knowledge = this.initializeKnowledge();

  constructor(private _knowledgeTrashFacade: KnowledgeTrashFacade,
    private _knowledgeFacade: KnowledgeFacade, private _modalService: NgbModal) { }

  ngOnInit(): void {
  }

  openEmptyTrashModal(emptyTrashModal: any) {
    this._modalService.open(emptyTrashModal);
  }

  async openDeleteModal(deleteModal: any) {
    this.loadKnowledge();
    this._modalService.open(deleteModal);
  }

  openRestoreModal(restoreModal: any) {
    this._modalService.open(restoreModal);
  }

  async emptyTrash() {
    await this._knowledgeTrashFacade.emptyTrash();

    if(this._modalService.hasOpenModals()) {
      this._modalService.dismissAll();
    }
  }

  async restoreItem() {
    let itemIdInput: HTMLInputElement = document.getElementById("itemId") as HTMLInputElement;

    await this._knowledgeTrashFacade.restoreKnowledge(itemIdInput.value);

    if(this._modalService.hasOpenModals()) {
      this._modalService.dismissAll();
    }
  }

  private async loadKnowledge() {
    let itemIdInput: HTMLInputElement = document.getElementById("itemId") as HTMLInputElement;

    let result = await this._knowledgeFacade.getKnowledge$(itemIdInput.value);

    result.subscribe(result => {
      this.knowledge = result;
    })
  }

  // Initializing an empty object of Knowledge
  private initializeKnowledge(): Knowledge {
    return {
      id: "",
      title: "",
      description: "",
      knowledgeImportance: KnowledgeImportance.Neutral,
      knowledgeLevel: KnowledgeLevel.Beginner,
      knowledgeTags: [],
      createdDate: new Date(),
      updatedDate: new Date(),
      isTrashItem: false,
      userId: ""
    };
  }

}
