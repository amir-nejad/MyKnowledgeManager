import { Component, OnInit, ViewChild, ElementRef, TemplateRef } from '@angular/core';
import { KnowledgeTagsFacade } from '../../knowledge-tags.facade';
import { AuthService } from 'src/app/core';
import { Router } from '@angular/router';
import { KnowledgeTag } from 'src/app/shared';
import { Observable } from 'rxjs';
import { ModalDismissReasons, NgbModal } from "@ng-bootstrap/ng-bootstrap"
import { CreateUpdateComponent } from '../../components/create-update/create-update.component';


@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
  styleUrls: ['./tags.component.scss']
})
export class TagsComponent implements OnInit {

  knowledgeTag: KnowledgeTag;
  knowledgeTags$: Observable<KnowledgeTag[]>;
  isUpdating$: Observable<boolean>;
  updateMode: boolean = false;

  constructor(private _knowledgeTagsFacade: KnowledgeTagsFacade,
    private _authService: AuthService, private router: Router, private modalService: NgbModal) {
    this.knowledgeTag = this.initializeKnowledgeTag();

    this.knowledgeTags$ = _knowledgeTagsFacade.getKnowledgeTags$();
    this.isUpdating$ = _knowledgeTagsFacade.isUpdating$();
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

    let updateItemIdInput: HTMLInputElement = document.getElementById("updateItemId") as HTMLInputElement;

    let result = await this._knowledgeTagsFacade.getKnowledgeTag$(updateItemIdInput.value);

    result.subscribe(tag => {
      this.knowledgeTag = tag;
    })

    this.modalService.open(content);
  }

  // Opening a modal for moving to trash a KnowledgeTag
  async openDeleteModal(trash: any) {
    let updateItemIdInput: HTMLInputElement = document.getElementById("updateItemId") as HTMLInputElement;

    let result = await this._knowledgeTagsFacade.getKnowledgeTag$(updateItemIdInput.value);

    result.subscribe(tag => {
      this.knowledgeTag = tag;
    })

    this.modalService.open(trash);
  }

  ngOnInit(): void {
    this.setUserId();
    this._knowledgeTagsFacade.loadKnowledgeTags();
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
