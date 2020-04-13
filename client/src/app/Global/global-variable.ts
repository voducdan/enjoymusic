import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable()
export class Global {
	API_URL: string = 'https://localhost:44319/api';
	IMAGES_URL: string = 'https://localhost:44319/static/images/';
	SONGS_URL: string = 'https://localhost:44319/static/Songs/';

	public handleError(operation = 'operation', result?: any) {
		return (error: any): Observable<any> => {
			console.error(error);
			return of(result);
		};
	}
}
