import { Component, OnInit, ViewChild, ElementRef, TemplateRef } from '@angular/core';
import { KnowledgeTagsFacade } from '../../knowledge-tags.facade';
import { AuthService } from 'src/app/core';
import { Router } from '@angular/router';
import { KnowledgeTag } from 'src/app/shared';
import { Observable } from 'rxjs';
import { ModalDismissReasons, NgbModal } from "@ng-bootstrap/ng-bootstrap"
import { CreateUpdateComponent } from '../../components/create-update/create-update.component';
import { KnowledgeTagsTrashFacade } from '../../knowledge-tags-trash.facade';


@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
  styleUrls: ['./tags.component.scss']
})
export class TagsComponent implements OnInit {

  knowledgeTag: KnowledgeTag;
  updateMode: boolean = false;
  trashItemsCount: number = 0;

  constructor(private _knowledgeTagsFacade: KnowledgeTagsFacade,
    private _authService: AuthService, private modalService: NgbModal) {
    this.knowledgeTag = this.initializeKnowledgeTag();
  }

  // Opening a modal for create a new KnowledgeTag
  openCreateModal(content: any) {
    this.knowledgeTag = this.initializeKnowledgeTag();
    this.knowledgeTag.id = crypto.randomUUID();
    this.setUserId();
    console.log(content);
    this.modalService.open(content);
  }

  // Opening a modal for update a KnowledgeTag
  async openUpdateModal(content: any) {
    this.updateMode = true;

    let itemIdInput: HTMLInputElement = document.getElementById("itemId") as HTMLInputElement;

    let result = await this._knowledgeTagsFacade.getKnowledgeTag$(itemIdInput.value);

    result.subscribe(tag => {
      this.knowledgeTag = tag;
    })

    this.modalService.open(content);
  }

  // Opening a modal for moving to trash a KnowledgeTag
  async openDeleteModal(trash: any) {
    let itemIdInput: HTMLInputElement = document.getElementById("itemId") as HTMLInputElement;

    let result = await this._knowledgeTagsFacade.getKnowledgeTag$(itemIdInput.value);

    result.subscribe(tag => {
      this.knowledgeTag = tag;
    })

    this.modalService.open(trash);
  }

  async ngOnInit(): Promise<void> {
    this.setUserId();
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

  private setUserId() {
    this._authService.getUserId().then(
      id => {
        this.knowledgeTag.userId = id;
      }
    ).catch(err => {
      console.log(err);
    })
  }
}
