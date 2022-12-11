import { Component, OnInit } from '@angular/core';
import { KnowledgeTagDTO } from '../../../../shared/index';
import { } from "@ng-bootstrap/ng-bootstrap";
import { KnowledgeTagsFacade } from '../../knowledge-tags.facade';
import { AuthService } from '../../../../core/services/auth.service';

@Component({
  selector: 'app-create-knowledge-tag',
  templateUrl: './create-knowledge-tag.component.html',
  styleUrls: ['./create-knowledge-tag.component.scss']
})
export class CreateKnowledgeTagComponent implements OnInit {
  knowledgeTagDTO: KnowledgeTagDTO = {
    id: "",
    tagName: "",
    createdDate: new Date(),
    updatedDate: new Date(),
    isTrashItem: false,
    userId: ""
  };

  constructor(private _knowledgeTagsFacade: KnowledgeTagsFacade, private _authService: AuthService) {
    this._authService.getUserId().then(
      id => this.knowledgeTagDTO.userId = id!
    )
    console.log(this.knowledgeTagDTO.userId);
  }

  ngOnInit(): void {
  }

  createKnowledgeTag() {
    this._knowledgeTagsFacade.addKnowledgeTag(this.knowledgeTagDTO);
  }
}
