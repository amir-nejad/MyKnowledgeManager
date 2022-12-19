import { HttpClient, HttpHandler, HttpHeaders } from "@angular/common/http";
import { AuthService } from '../../../core/services/auth.service';
import { Observable } from 'rxjs';
import { KnowledgeTag, KnowledgeTagDTO } from '../../../shared';
import { Injectable } from "@angular/core";
import { Constants } from "src/app/configs/constants";

@Injectable({
  providedIn: "root"
})
export class KnowledgeTagsApi {

  accessToken: string = "";

  constructor(private _http: HttpClient, private _authService: AuthService) {
    this._authService.getAccessToken().then(token => {
      this.accessToken = token!;
    });
  }

  knowledgeTag: KnowledgeTag = {
    id: null,
    tagName: "",
    createdDate: new Date(),
    updatedDate: new Date(),
    isTrashItem: false,
    userId: ""
  }

  knowledgeTags: KnowledgeTag[] = [];

  headers: HttpHeaders = new HttpHeaders();
  readonly endpoint = `${Constants.apiRoot}/knowledgeTags`

  async getKnowledgeTags$(): Promise<Observable<KnowledgeTag[]>> {

    this.setHeaders();

    return this._http.get<KnowledgeTag[]>(this.endpoint, { headers: this.headers });
  }


  async createKnowledgeTag$(knowledgeTagDTO: KnowledgeTag): Promise<Observable<KnowledgeTag>> {
    this.setHeaders();
    return this._http.post<KnowledgeTag>(this.endpoint, knowledgeTagDTO, { headers: this.headers });
  }

  private setHeaders(contentType: string = "content/JSON") {
    this.headers = new HttpHeaders(
      {
        "Authorization": `Bearer ${this.accessToken}`,
        "ContentType": contentType
      }
    )
  }
}
