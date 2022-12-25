import { Component, OnInit } from '@angular/core';
import { KnowledgeTagsFacade } from '../../knowledge-tags.facade';
import { AuthService } from 'src/app/core';
import { Router } from '@angular/router';
import { KnowledgeTag } from 'src/app/shared';
import { Observable } from 'rxjs';
import { ModalDismissReasons, NgbModal } from "@ng-bootstrap/ng-bootstrap"

@Component({
  selector: 'app-tags',
  templateUrl: './tags.component.html',
  styleUrls: ['./tags.component.scss']
})
export class TagsComponent implements OnInit {

  knowledgeTag: KnowledgeTag;
  knowledgeTags$: Observable<KnowledgeTag[]>;
  isUpdating$: Observable<boolean>;

  constructor(private _knowledgeTagsFacade: KnowledgeTagsFacade,
              private _authService: AuthService, private router: Router, private modalService: NgbModal) {
    this.knowledgeTag = {
      id: crypto.randomUUID(),
      tagName: "",
      createdDate: new Date(),
      updatedDate: new Date(),
      isTrashItem: false,
      userId: ""
    };

    this.knowledgeTags$ = _knowledgeTagsFacade.getKnowledgeTags$();
    this.isUpdating$ = _knowledgeTagsFacade.isUpdating$();
  }

  openModal(content: any) {
    this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
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
