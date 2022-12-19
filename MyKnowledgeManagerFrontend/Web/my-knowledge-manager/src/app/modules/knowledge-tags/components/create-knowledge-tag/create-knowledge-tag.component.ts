import { Component, OnInit } from '@angular/core';
import { KnowledgeTagDTO } from '../../../../shared/index';
import { } from "@ng-bootstrap/ng-bootstrap";
import { KnowledgeTagsFacade } from '../../knowledge-tags.facade';
import { AuthService } from '../../../../core/services/auth.service';
import { KnowledgeTag } from '../../../../shared/models/knowledge-tag';
import { KnowledgeTagsApi } from '../../api/knowledge-tags.api';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-create-knowledge-tag',
  templateUrl: './create-knowledge-tag.component.html',
  styleUrls: ['./create-knowledge-tag.component.scss']
})
export class CreateKnowledgeTagComponent implements OnInit {
  knowledgeTag: KnowledgeTag;

  constructor(private _knowledgeTagApi: KnowledgeTagsApi, private _authService: AuthService) {
    this.knowledgeTag = {
      id: crypto.randomUUID(),
      tagName: "",
      createdDate: new Date(),
      updatedDate: new Date(),
      isTrashItem: false,
      userId: ""
    };
  }

  ngOnInit(): void {
    this._authService.getUserId().then(
      id => {
        this.knowledgeTag.userId = id;
      }
    ).catch(err => {
      console.log(err);
    })
  }

  async createKnowledgeTag() {
    
  }
}
