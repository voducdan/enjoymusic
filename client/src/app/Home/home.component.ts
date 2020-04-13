import { Component } from '@angular/core';
import { SongThumnailService, ISongThumnail } from './share/index';
@Component({
	selector: 'home',
	templateUrl: './home.component.html',
})
export class HomeComponent {
	constructor(private songThumnailService: SongThumnailService) {}

	topListen: ISongThumnail[];
	topDownload: ISongThumnail[];
	suggest: ISongThumnail[];

	ngOnInit() {
		this.songThumnailService.getSongs('nghe-nhieu-nhat').subscribe(res => {
			this.topListen = res;
		});
		this.songThumnailService.getSongs('tai-nhieu-nhat').subscribe(res => {
			this.topDownload = res;
		});
		this.songThumnailService.getSongs('de-cu').subscribe(res => {
			this.suggest = res;
		});
	}
}
