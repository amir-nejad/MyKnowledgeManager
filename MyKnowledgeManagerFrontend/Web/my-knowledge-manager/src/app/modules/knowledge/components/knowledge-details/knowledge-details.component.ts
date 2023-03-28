import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { KnowledgeFacade } from '../../knowledge.facade';
import { Knowledge, KnowledgeImportance, KnowledgeLevel } from 'src/app/shared';

@Component({
  selector: 'app-knowledge-details',
  templateUrl: './knowledge-details.component.html',
  styleUrls: ['./knowledge-details.component.scss']
})
export class KnowledgeDetailsComponent implements OnInit {

  @Input() knowledge: Knowledge | null = null

  constructor(private route: ActivatedRoute, private knowledgeFacade: KnowledgeFacade) { }

  ngOnInit(): void {
  }
}
