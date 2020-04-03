import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Global } from '../../Global/global-variable';
import { pipe } from 'rxjs';
import { catchError } from 'rxjs/operators';
@Injectable()
export class ListenService {
	constructor(private http: HttpClient, private global: Global) {}

	getTopListen() {
		return this.http
			.get(`${this.global.API_URL}/bai-hat/nghe-nhieu-nhat`)
			.pipe(catchError(this.global.handleError('GetTopListen')));
	}
}
