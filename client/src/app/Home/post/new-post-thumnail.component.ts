import { Component, Input } from '@angular/core';
import { Global } from '../../Global/global-variable';

@Component({
	selector: 'new-post-thumnail',
	templateUrl: './new-post-thumnail.component.html',
	styleUrls: ['./new-post-thumnail.component.css'],
})
export class NewPostThumnailComponent {
	@Input() song;
	constructor(private global:Global){}
	ngOnInit() {
		this.song.avt = this.global.IMAGES_URL + this.song.avt;
	}
}
