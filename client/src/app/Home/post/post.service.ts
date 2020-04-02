import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { Observable, of } from 'rxjs';
@Injectable()
export class PostService {
	constructor(private http: HttpClient) {}

	getNewSongs() {
		return this.http.get('https://localhost:44319/api/bai-hat').pipe(catchError(this.handleError('getNewSongs')));
	}

	private handleError(operation = 'operation', result?: any) {
		return (error: any): Observable<any> => {
			console.error(error);
			return of(result);
		};
	}
}
