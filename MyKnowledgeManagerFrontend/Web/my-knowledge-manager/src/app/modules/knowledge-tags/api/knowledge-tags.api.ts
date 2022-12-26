import { HttpClient, HttpHandler, HttpHeaders, HttpResponse } from '@angular/common/http';
import { AuthService } from '../../../core/services/auth.service';
import { Observable, catchError, finalize } from 'rxjs';
import { KnowledgeTag } from '../../../shared';
import { Injectable } from "@angular/core";
import { Constants } from "src/app/configs/constants";

@Injectable({
  providedIn: "root"
})
export class KnowledgeTagsApi {

  accessToken: string = "";

  constructor(private _http: HttpClient, private _authService: AuthService) {
    // Getting authorization access token from the current User.
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

  // Base URL
  readonly endpoint = `${Constants.apiRoot}/knowledgeTags`

  async getKnowledgeTags$(): Promise<Observable<KnowledgeTag[]>> {

    this.setHeaders();

    return this._http.get<KnowledgeTag[]>(this.endpoint, { headers: this.headers });
  }

  async getKnowledgeTag$(id: string): Promise<Observable<KnowledgeTag>> {
    this.setHeaders();
    return this._http.get<KnowledgeTag>(`${this.endpoint}/getKnowledgeTagById/${id}`, { headers: this.headers });
  }


  async createKnowledgeTag$(knowledgeTag: KnowledgeTag): Promise<Observable<KnowledgeTag>> {
    this.setHeaders();
    return this._http.post<KnowledgeTag>(this.endpoint, knowledgeTag, { headers: this.headers });
  }

  async updateKnowledgeTag$(knowledgeTag: KnowledgeTag): Promise<Observable<KnowledgeTag>> {
    this.setHeaders();
    return this._http.put<KnowledgeTag>(`${this.endpoint}/${knowledgeTag.id}`, knowledgeTag, { headers: this.headers });
  }

  async moveToTrashKnowledgeTag$(id: string): Promise<Observable<any>> {
    this.setHeaders();
    console.log(id);
    return this._http.put(`${this.endpoint}/moveKnowledgeTagToTrash/${id}`, null, { headers: this.headers });
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
