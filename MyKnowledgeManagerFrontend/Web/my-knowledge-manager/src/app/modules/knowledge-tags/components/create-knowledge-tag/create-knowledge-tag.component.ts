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
  knowledgeTag: KnowledgeTag = {
    id: "",
    tagName: "",
    createdDate: new Date(),
    updatedDate: new Date(),
    isTrashItem: false,
    userId: ""
  };

  constructor(private _knowledgeTagApi: KnowledgeTagsApi, private _authService: AuthService) {
    this._authService.getUserId().then(
      id => this.knowledgeTag.userId = id!
    )
    console.log(this.knowledgeTag.userId);
  }

  ngOnInit(): void {
  }

  async createKnowledgeTag() {
    console.log("createKnowledgeTag called.")
    // this._knowledgeTagsFacade.addKnowledgeTag(this.knowledgeTag);
    // this._knowledgeTagApi.get();
    let result = (await this._knowledgeTagApi.getKnowledgeTags$()).forEach(
      x => {
        console.log(x);
      }
    );
    console.log(result);
  }
}
