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

  }

  knowledgeTag: KnowledgeTag = {
    id: "",
    tagName: "",
    createdDate: new Date(),
    updatedDate: new Date(),
    isTrashItem: false,
    userId: ""
  }

  knowledgeTags: KnowledgeTag[] = [];

  authorizationHeader: HttpHeaders = new HttpHeaders();
  readonly endpoint = `${Constants.apiRoot}/knowledgeTags`

  async getKnowledgeTags$(): Promise<Observable<KnowledgeTag[]>> {
    let token = await this._authService.getAccessToken();
    console.log(token);
    this.accessToken = token!;
    
    let result = this._http.get<KnowledgeTag[]>(this.endpoint, { headers: this.authorizationHeader })
    .pipe(data => {
      console.log(data);
      return data;
    });

    return result;
  }


  async get() {
    let token = await this._authService.getAccessToken();
    console.log(token);
    this.accessToken = token!;
    
    console.log(this.accessToken);
    this.authorizationHeader = new HttpHeaders().set('Authorization', `Bearer ${this.accessToken}`);
    console.log(this.authorizationHeader);
    let result = this._http.get(this.endpoint, { headers: this.authorizationHeader })
    .pipe(data => {
      console.log(data);
      data.forEach(x => {
        console.log(x);
      })
      return data;
    });
  }

  // createKnowledgeTag$(knowledgeTagDTO: KnowledgeTag): Observable<KnowledgeTag> {
  //   return this._http.post<KnowledgeTagDTO>(this.endpoint, knowledgeTagDTO, { headers: this.authorizationHeader});
  // }

}
