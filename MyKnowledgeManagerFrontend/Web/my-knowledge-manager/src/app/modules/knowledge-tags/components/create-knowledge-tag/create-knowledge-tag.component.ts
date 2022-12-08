import { Component, OnInit } from '@angular/core';
import { KnowledgeDTO, KnowledgeImportance, KnowledgeLevel } from '../../../../shared/index';
import { AuthService } from '../../../../core/index';

@Component({
  selector: 'app-create-knowledge-tag',
  templateUrl: './create-knowledge-tag.component.html',
  styleUrls: ['./create-knowledge-tag.component.scss']
})
export class CreateKnowledgeTagComponent implements OnInit {
  knowledgeTagDTO: KnowledgeDTO = {
    id: "",
    title: "",
    description: '',
    knowledgeImportance: KnowledgeImportance.NotImportant,
    knowledgeLevel: KnowledgeLevel.Beginner,
    knowledgeTags: [],
    isTrashItem: false,
    userId: ''
  };

  constructor(private _authService: AuthService) { }

  ngOnInit(): void {
  }

}
