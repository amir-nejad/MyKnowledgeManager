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

  openCreateModal(content: any) {
    this.knowledgeTag = this.initializeKnowledgeTag();
    this.knowledgeTag.id = crypto.randomUUID();
    this.setUserId();
    console.log(content);
    this.modalService.open(content);
  }

  openUpdateModal(content: any, id: string) {
    this.knowledgeTag = this.initializeKnowledgeTag();
    this.updateMode = true;
    this.knowledgeTag.id = id;
    this.setUserId();
    console.log(this.knowledgeTag.id);
    console.log(this.knowledgeTag.userId);
    this.modalService.open(content);
  }

  ngOnInit(): void {
    this.setUserId();
    this._knowledgeTagsFacade.loadKnowledgeTags();
  }

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
