import { HttpClient, HttpHandler, HttpHeaders } from "@angular/common/http";
import { AuthService } from '../../../core/services/auth.service';
import { Observable } from 'rxjs';
import { Constants } from '../../../configs/constants';
import { KnowledgeTagDTO } from '../../../shared/models/knowledge-tag-dto';
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: "root"
})
export class KnowledgeTagsApi {
  constructor(private _http: HttpClient, private _authService: AuthService) {
    let token = _authService.getAccessToken();
    this.authorizationHeader = new HttpHeaders().set('Authorization', `Bearer ${token}`);
  }

  readonly authorizationHeader;
  readonly endpoint = `${Constants.apiRoot}/knowledgeTags`

  getKnowledgeTags$(): Observable<KnowledgeTagDTO[]> {
    return this._http.get<KnowledgeTagDTO[]>(this.endpoint, { headers: this.authorizationHeader });
  }

  createKnowledgeTag$(knowledgeTagDTO: KnowledgeTagDTO): Observable<KnowledgeTagDTO> {
    return this._http.post<KnowledgeTagDTO>(this.endpoint, knowledgeTagDTO, { headers: this.authorizationHeader});
  }

}
