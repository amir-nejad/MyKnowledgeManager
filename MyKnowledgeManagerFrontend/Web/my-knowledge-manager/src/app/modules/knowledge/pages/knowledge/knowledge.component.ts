import { Component, OnInit } from '@angular/core';
import { Knowledge, KnowledgeImportance, KnowledgeLevel } from 'src/app/shared';
import { KnowledgeFacade } from '../../knowledge.facade';
import { AuthService } from 'src/app/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import * as tagify from 'ngx-tagify';

@Component({
  selector: 'app-knowledge',
  templateUrl: './knowledge.component.html',
  styleUrls: ['./knowledge.component.scss']
})
export class KnowledgeComponent implements OnInit {

  knowledge: Knowledge;
  updateMode: boolean = false;
  trashItemsCount: number = 0;

  constructor(private _knowledgeFacade: KnowledgeFacade,
    private _tagifyService: tagify.TagifyService,
    private _authService: AuthService, private modalService: NgbModal) {
    this.knowledge = this.initializeKnowledge();
  }

  // Opening a modal for create a new Knowledge
  openCreateModal(content: any) {
    this.updateMode = false;
    this.knowledge = this.initializeKnowledge();
    this.knowledge.id = crypto.randomUUID();
    this.setUserId();
    this.modalService.open(content, { size: 'lg' });
  }

  // Opening a modal for update a Knowledge
  async openUpdateModal(content: any) {
    this.updateMode = true;

    let itemIdInput: HTMLInputElement = document.getElementById("itemId") as HTMLInputElement;

    let result = await this._knowledgeFacade.getKnowledge$(itemIdInput.value, true);

    result.subscribe(knowledge => {
      this.knowledge = knowledge;
      this._tagifyService.get("tags").addTags(this.knowledge.knowledgeTags);
    })

    this.modalService.open(content, { size: 'lg' });
  }

  // Opening a modal for moving to trash a Knowledge
  async openDeleteModal(trash: any) {
    let itemIdInput: HTMLInputElement = document.getElementById("itemId") as HTMLInputElement;

    let result = await this._knowledgeFacade.getKnowledge$(itemIdInput.value);

    result.subscribe(knowledge => {
      this.knowledge = knowledge;
    })

    this.modalService.open(trash);
  }

  async ngOnInit(): Promise<void> {
    this.setUserId();
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

  private setUserId() {
    this._authService.getUserId().then(
      id => {
        this.knowledge.userId = id;
      }
    ).catch(err => {
      console.log(err);
    })
  }
}
