import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { KnowledgeFacade } from '../../knowledge.facade';
import { Knowledge } from '../../../../shared/models/knowledge';

@Component({
  selector: 'app-view-knowledge',
  templateUrl: './view-knowledge.component.html',
  styleUrls: ['./view-knowledge.component.scss']
})
export class ViewKnowledgeComponent implements OnInit {

  id: string = "";
  knowledge: Knowledge | null = null;

  constructor(private route: ActivatedRoute, private knowledgeFacade: KnowledgeFacade) { }

  async ngOnInit(): Promise<void> {
    this.id = this.route.snapshot.paramMap.get('id') || '';

    if (this.id) {
      await this.loadKnowledge();
    }
  }

  async loadKnowledge() {
    (await this.knowledgeFacade.getKnowledge$(this.id, true))
    .subscribe(x => this.knowledge = x);
  }
}
