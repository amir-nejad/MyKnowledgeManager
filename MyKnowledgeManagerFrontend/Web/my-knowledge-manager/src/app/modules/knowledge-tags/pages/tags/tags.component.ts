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
    this.knowledgeTag = {
      id: "",
      tagName: "",
      createdDate: new Date(),
      updatedDate: new Date(),
      isTrashItem: false,
      userId: ""
    };

    this.knowledgeTags$ = _knowledgeTagsFacade.getKnowledgeTags$();
    this.isUpdating$ = _knowledgeTagsFacade.isUpdating$();
  }

  openCreateModal(content: any) {
    this.knowledgeTag.id = crypto.randomUUID();
    console.log(content);
    this.modalService.open(content);
  }

  openUpdateModal(content: any, id: string) {
    this.updateMode = true;
    this.knowledgeTag.id = id;
    this.modalService.open(content).result.then(
      (result => {
        console.log(result);
      }),
    );
  }

  ngOnInit(): void {
    this._authService.getUserId().then(
      id => {
        this.knowledgeTag.userId = id;
      }
    ).catch(err => {
      console.log(err);
    })

    this._knowledgeTagsFacade.loadKnowledgeTags();
  }
}
