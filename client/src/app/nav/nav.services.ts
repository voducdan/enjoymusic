import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Global } from '../Global/global-variable';
@Injectable()
export class NavService {
	constructor(private http: HttpClient, private global: Global) {}
	getAllCategories() {
		return this.http
			.get(`${this.global.API_URL}/the-loai`)
			.pipe(catchError(this.handleError('getCategories')));
	}

	private handleError(operation = 'operation', result?: any) {
		return (error: any): Observable<any> => {
			console.error(error);
			return of(result);
		};
	}
}
