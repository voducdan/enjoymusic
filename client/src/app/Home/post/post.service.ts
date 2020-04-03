import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

import { Global } from '../../Global/global-variable';
@Injectable()
export class PostService {
	constructor(private http: HttpClient, private global: Global) {}

	getNewSongs() {
		return this.http
			.get(`${this.global.API_URL}/bai-hat`)
			.pipe(catchError(this.global.handleError('getNewSongs')));
	}
}
