import { HttpClient, HttpHandler, HttpHeaders, HttpResponse } from '@angular/common/http';
import { AuthService } from '../../../core/services/auth.service';
import { Observable, catchError, finalize } from 'rxjs';
import { KnowledgeTag } from '../../../shared';
import { Injectable } from "@angular/core";
import { Constants } from "src/app/configs/constants";

/**
 * This service manages all interactions between this Angular app and Api server.
 */
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

  // General CRUD API Functions //

  /**
   * This function can get all KnowledgeTag objects as an Observable from the API.
   */
  async getKnowledgeTags$(): Promise<Observable<KnowledgeTag[]>> {

    this.setHeaders();

    return this._http.get<KnowledgeTag[]>(this.endpoint, { headers: this.headers });
  }

  /**
   * This function can get one KnowledgeTag as an Observable based on provided Id from the API.
   */
  async getKnowledgeTag$(id: string): Promise<Observable<KnowledgeTag>> {
    this.setHeaders();
    return this._http.get<KnowledgeTag>(`${this.endpoint}/getKnowledgeTagById/${id}`, { headers: this.headers });
  }

  /**
   * This function can create a KnowledgeTag in the database using the API's POST method.
   * @param knowledgeTag Target KnowledgeTag for database creation.
   * @returns Added KnowledgeTag as an Observable in which can contain error response.
   */
  async createKnowledgeTag$(knowledgeTag: KnowledgeTag): Promise<Observable<KnowledgeTag>> {
    this.setHeaders();
    return this._http.post<KnowledgeTag>(this.endpoint, knowledgeTag, { headers: this.headers });
  }

  /**
   * This function can update a KnowledgeTag in the database using the API's PUT method.
   * @param knowledgeTag Target KnowledgeTag for database update.
   * @returns Added KnowledgeTag as an Observable in which can contain error response.
   */
  async updateKnowledgeTag$(knowledgeTag: KnowledgeTag): Promise<Observable<KnowledgeTag>> {
    this.setHeaders();
    return this._http.put<KnowledgeTag>(`${this.endpoint}/${knowledgeTag.id}`, knowledgeTag, { headers: this.headers });
  }

  /**
   * This function can delete permanently a specific KnowledgeTag.
   * @param id The Id of the target KnowledgeTag for deletion.
   * @returns
   */
  async deleteKnowledgeTag$(id: string): Promise<Observable<any>> {
    this.setHeaders();
    return this._http.delete(`${this.endpoint}/${id}`, { headers: this.headers });
  }

  // Trash Related API Functions //

  /**
   * This function can move a KnowledgeTag to the Trash by using API's PUT method.
   * @param id The Id of the target KnowledgeTag
   * @returns
   */
  async moveToTrashKnowledgeTag$(id: string): Promise<Observable<any>> {
    this.setHeaders();
    return this._http.put(`${this.endpoint}/moveKnowledgeTagToTrash/${id}`, null, { headers: this.headers });
  }

  /**
   * This function can get a list of KnowledgeTag trash items.
   * @returns A list of KnowledgeTag objects that moved to the Trash
   */
  async getTrashKnowledgeTags$(): Promise<Observable<KnowledgeTag[]>> {
    this.setHeaders();
    return this._http.get<KnowledgeTag[]>(`${this.endpoint}/getTrashKnowledgeTags`, { headers: this.headers });
  }

  /**
   * This function can restore a KnowledgeTag from the trash.
   * @param id The Id of the target KnowledgeTag for restore.
   * @returns
   */
  async restoreKnowledgeTag$(id: string): Promise<Observable<any>> {
    this.setHeaders();
    return this._http.put(`${this.endpoint}/restoreKnowledgeTag/${id}`, null, { headers: this.headers });
  }

  /**
   * This function can delete all permanently KnowledgeTag trash items.
   * @returns
   */
  async deleteKnowledgeTagTrashItems$(): Promise<Observable<any>> {
    this.setHeaders();
    return this._http.delete(`${this.endpoint}/deleteTrashItems`, { headers: this.headers });
  }

  // Set HTTP Headers
  private setHeaders(contentType: string = "content/JSON") {
    this.headers = new HttpHeaders(
      {
        "Authorization": `Bearer ${this.accessToken}`,
        "ContentType": contentType
      }
    )
  }
}
