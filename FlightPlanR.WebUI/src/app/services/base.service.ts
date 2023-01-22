import {Injectable} from "@angular/core";
import {map, Observable} from "rxjs";
import {HttpClient, HttpHeaders, HttpResponse} from "@angular/common/http";
import {ApiRoutes} from "../api.routes";
import {environment} from "../../environments/environment";

export const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  }),
  body: {},
  observe: 'response' as 'body',
  params: {},
  withCredentials: true
};

@Injectable()
export class BaseApiService {
  protected apiRoutes = ApiRoutes;

  constructor(protected http: HttpClient) {
  }

  public get<T>(endpoint: string, params?: any, options?: any): Observable<T> {
    return this.request('GET', endpoint, null, params, options);
  }

  public post<T>(endpoint: string, body?: unknown): Observable<T> {
    return this.request('POST', endpoint, body);
  }

  public put<T>(endpoint: string, body?: unknown): Observable<T> {
    return this.request('PUT', endpoint, body);
  }

  public delete<T>(endpoint: string): Observable<T> {
    return this.request('DELETE', endpoint);
  }

  protected request<T>(method: string, endpoint: string, body?: any, params?: any, options?: {}): Observable<T> {
    const requestOptions = Object.assign({}, httpOptions);
    Object.assign(requestOptions, options);
    requestOptions.body = body;
    requestOptions.params = params;

    return this.http.request<HttpResponse<T>>(method, `${this.apiRoutes.baseUrl}/${endpoint}`, requestOptions).pipe(
      map((response: HttpResponse<T>) => response.body as T)
    );
  }
}
