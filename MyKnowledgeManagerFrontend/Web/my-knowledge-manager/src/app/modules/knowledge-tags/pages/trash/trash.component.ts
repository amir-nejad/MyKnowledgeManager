import { Component, OnInit, resolveForwardRef } from '@angular/core';
import { KnowledgeTag } from '../../../../shared/models/knowledge-tag';
import { KnowledgeTagsTrashFacade } from '../../knowledge-tags-trash.facade';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { AuthService } from 'src/app/core';

@Component({
  selector: 'app-trash',
  templateUrl: './trash.component.html',
  styleUrls: ['./trash.component.scss']
})
export class TrashComponent implements OnInit {

  isUpdating: boolean = false;

  constructor(private _knowledgeTagsTrashFacade: KnowledgeTagsTrashFacade,
    private _authService: AuthService, private _modalService: NgbModal) { }

  ngOnInit(): void {
    this._knowledgeTagsTrashFacade.loadTrashKnowledgeTags();
  }

  openEmptyTrashModal(emptyTrashModal: any) {
    this._modalService.open(emptyTrashModal);
  }

  openDeleteModal(deleteModal: any) {
    this._modalService.open(deleteModal);
  }

  openRestoreModal(restoreModal: any) {
    this._modalService.open(restoreModal);
  }
}
