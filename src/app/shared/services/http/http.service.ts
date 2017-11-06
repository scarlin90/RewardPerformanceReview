import { Injectable } from '@angular/core';
import { Http, Response, RequestOptionsArgs, RequestOptions, Headers } from '@angular/http';

import { HttpResponse } from './http-response';

@Injectable()
export class HttpService {

    header: Headers;

    constructor (
        private http: Http
    ) {
        this.header = new Headers({ 'Content-Type': 'application/json' });
    }

    /**
     * Send a GET request to specified URL
     * @param url Url to send GET request
     * @param options Options to send with request
     */
    get<T>(url: string, options?: RequestOptionsArgs): HttpResponse<T> {
        if (options === undefined) {
            options = {headers : this.header};
        }
        return new HttpResponse<T>(this.http.get(url, options));
    }

    /**
     * Send a DELETE request to specified URL
     * @param url Url to send DELETE request
     * @param options Options to send with request
     */
    delete<T>(url: string, options?: RequestOptionsArgs): HttpResponse<T> {
        if (options === undefined) {
            options = {headers : this.header};
        }
        return new HttpResponse<T>(this.http.delete(url, options));
    }

    /**
     * Send a POST request to specified URL
     * @param url Url to send POST request
     * @param body POST data to send with request
     * @param options Options to send with request
     */
    post<T>(url: string, body: any, options?: RequestOptionsArgs): HttpResponse<T> {
        if (options === undefined) {
            options = {headers : this.header};
        }
        return new HttpResponse<T>(this.http.post(url, this.transformRequestData(options, body), options));
    }

    /**
     * Send a PUT request to specified URL
     * @param url Url to send PUT request
     * @param body PUT data to send with request
     * @param options Options to send with request
     */
    put<T>(url: string, body: any, options?: RequestOptionsArgs): HttpResponse<T> {
        if (options === undefined) {
            options = {headers : this.header};
        }
        return new HttpResponse<T>(this.http.put(url, this.transformRequestData(options, body), options));
    }

    /**
     * Transform request body based on Content-Type header
     * @param options Request Option Arguments containing the headers for the request
     * @param data The data to be transformed
     */
    transformRequestData(options: RequestOptionsArgs, data: any) {
        if (data === undefined) {
            return undefined;
        }

        if (options.headers.getAll('Content-Type').find(c => c === 'application/json')) {
            return JSON.stringify(data);
        }

        return data;
    }
}