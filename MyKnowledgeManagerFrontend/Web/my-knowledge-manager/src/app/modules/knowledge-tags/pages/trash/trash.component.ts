import { Component, OnInit, resolveForwardRef } from '@angular/core';
import { KnowledgeTag } from '../../../../shared/models/knowledge-tag';
import { KnowledgeTagsTrashFacade } from '../../knowledge-tags-trash.facade';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from 'src/app/core';
import { KnowledgeTagsFacade } from '../../knowledge-tags.facade';

@Component({
  selector: 'app-trash',
  templateUrl: './trash.component.html',
  styleUrls: ['./trash.component.scss']
})
export class TrashComponent implements OnInit {

  isUpdating: boolean = false;
  knowledgeTag: KnowledgeTag = this.initializeKnowledgeTag();

  constructor(private _knowledgeTagsTrashFacade: KnowledgeTagsTrashFacade,
    private _knowledgeTagsFacade: KnowledgeTagsFacade,
    private _authService: AuthService, private _modalService: NgbModal) { }

  ngOnInit(): void {
  }

  openEmptyTrashModal(emptyTrashModal: any) {
    this._modalService.open(emptyTrashModal);
  }

  async openDeleteModal(deleteModal: any) {
    this.loadKnowledgeTag();
    this._modalService.open(deleteModal);
  }

  openRestoreModal(restoreModal: any) {
    this._modalService.open(restoreModal);
  }

  async emptyTrash() {
    await this._knowledgeTagsTrashFacade.emptyTrash();

    if(this._modalService.hasOpenModals()) {
      this._modalService.dismissAll();
    }
  }

  async restoreItem() {
    let itemIdInput: HTMLInputElement = document.getElementById("itemId") as HTMLInputElement;

    await this._knowledgeTagsTrashFacade.restoreKnowledgeTag(itemIdInput.value);

    if(this._modalService.hasOpenModals()) {
      this._modalService.dismissAll();
    }
  }

  private async loadKnowledgeTag() {
    let itemIdInput: HTMLInputElement = document.getElementById("itemId") as HTMLInputElement;

    let result = await this._knowledgeTagsFacade.getKnowledgeTag$(itemIdInput.value);

    result.subscribe(tag => {
      this.knowledgeTag = tag;
    })
  }

  // Initializing an empty object of KnowledgeTag
  private initializeKnowledgeTag(): KnowledgeTag {
    return {
      id: "",
      tagName: "",
      createdDate: new Date(),
      updatedDate: new Date(),
      isTrashItem: false,
      userId: ""
    };
  }
}
