import { HttpClient, HttpHandler, HttpHeaders, HttpResponse } from '@angular/common/http';
import { AuthService } from '../../../core/services/auth.service';
import { Observable, catchError, finalize } from 'rxjs';
import { Knowledge, KnowledgeImportance, KnowledgeLevel } from '../../../shared';
import { Injectable } from "@angular/core";
import { Constants } from "src/app/configs/constants";

/**
 * This service manages all interactions between this Angular app and Api server.
 */
@Injectable({
  providedIn: "root"
})
export class KnowledgeApi {

  accessToken: string = "";

  constructor(private _http: HttpClient, private _authService: AuthService) {
    // Getting authorization access token from the current User.
    this._authService.getAccessToken().then(token => {
      this.accessToken = token!;
    });
  }

  headers: HttpHeaders = new HttpHeaders();

  // Base URL
  readonly endpoint = `${Constants.apiRoot}/knowledge`

  // General CRUD API Functions //

  /**
   * This function can get all Knowledge objects as an Observable from the API.
   */
  async getKnowledgeList$(): Promise<Observable<Knowledge[]>> {

    this.setHeaders();

    return this._http.get<Knowledge[]>(this.endpoint, { headers: this.headers });
  }

  /**
   * This function can get one Knowledge as an Observable based on provided Id from the API.
   */
  async getKnowledge$(id: string): Promise<Observable<Knowledge>> {
    this.setHeaders();
    return this._http.get<Knowledge>(`${this.endpoint}/getKnowledgeById/${id}`, { headers: this.headers });
  }

  /**
   * This function can create a Knowledge in the database using the API's POST method.
   * @param knowledge Target Knowledge for database creation.
   * @returns Added Knowledge as an Observable in which can contain error response.
   */
  async createKnowledge$(knowledge: Knowledge): Promise<Observable<Knowledge>> {
    this.setHeaders();
    return this._http.post<Knowledge>(this.endpoint, knowledge, { headers: this.headers });
  }

  /**
   * This function can update a Knowledge in the database using the API's PUT method.
   * @param knowledge Target Knowledge for database update.
   * @returns Added Knowledge as an Observable in which can contain error response.
   */
  async updateKnowledge$(knowledge: Knowledge): Promise<Observable<Knowledge>> {
    this.setHeaders();
    return this._http.put<Knowledge>(`${this.endpoint}/${knowledge.id}`, knowledge, { headers: this.headers });
  }

  /**
   * This function can delete permanently a specific Knowledge.
   * @param id The Id of the target Knowledge for deletion.
   * @returns
   */
  async deleteKnowledge$(id: string): Promise<Observable<any>> {
    this.setHeaders();
    return this._http.delete(`${this.endpoint}/${id}`, { headers: this.headers });
  }

  // Trash Related API Functions //

  /**
   * This function can move a Knowledge to the Trash by using API's PUT method.
   * @param id The Id of the target Knowledge
   * @returns
   */
  async moveToTrashKnowledge$(id: string): Promise<Observable<any>> {
    this.setHeaders();
    return this._http.put(`${this.endpoint}/moveKnowledgeToTrash/${id}`, null, { headers: this.headers });
  }

  /**
   * This function can get a list of Knowledge trash items.
   * @returns A list of Knowledge objects that moved to the Trash
   */
  async getTrashKnowledge$(): Promise<Observable<Knowledge[]>> {
    this.setHeaders();
    return this._http.get<Knowledge[]>(`${this.endpoint}/getTrashKnowledge`, { headers: this.headers });
  }

  /**
   * This function can restore a Knowledge from the trash.
   * @param id The Id of the target Knowledge for restore.
   * @returns
   */
  async restoreKnowledge$(id: string): Promise<Observable<any>> {
    this.setHeaders();
    return this._http.put(`${this.endpoint}/restoreKnowledge/${id}`, null, { headers: this.headers });
  }

  /**
   * This function can delete all permanently Knowledge trash items.
   * @returns
   */
  async deleteKnowledgeTrashItems$(): Promise<Observable<any>> {
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
