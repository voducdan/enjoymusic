import { Component, Input } from '@angular/core';
import { Global } from 'src/app/Global/global-variable';
import { ISongThumnail } from './song-thumnail.model';

@Component({
	selector: 'song-thumnail',
	templateUrl: './song-thumnail.component.html',
	styleUrls: ['./song-thumnail.component.css'],
})
export class SongThumnailComponent {
	@Input() songs;
	@Input() title;
	mapedSongs: ISongThumnail[] = [];

	constructor(private global: Global) {}

	ngOnChanges() {
		if (this.songs) {
			this.songs.map(song => {
				this.mapedSongs.push(song);
				this.mapedSongs[this.mapedSongs.length - 1].avt =
					this.global.IMAGES_URL +
					this.mapedSongs[this.mapedSongs.length - 1].avt;
			});
		}
	}

	ngOnInit() {}
}
