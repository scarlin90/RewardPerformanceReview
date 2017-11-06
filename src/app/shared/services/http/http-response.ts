import { Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

export class HttpResponse<T> {

    constructor(
        public observableResponse: Observable<Response>) {

    }

    /**
     * Get the data from the response
     */
    public responseData(): Observable<T> {
        return this.observableResponse.map(res =>
            <T>res.json() || {}).catch(this.handleError);
    }

    /**
     * Handle an error that occurred with the request
     * @param error The error to handle
     */
    private handleError(error: Response | any) {
        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            console.error('Http Response : ' + error.status + err);
        } else {
            console.error('Http Response : ' + error.message);
        }
        return Observable.throw(error);
    }
}
