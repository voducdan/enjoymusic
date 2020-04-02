import {Component} from '@angular/core'

import { PostService } from './post.service';

@Component({
    selector:'new-post',
    templateUrl:'./new-post.component.html',
    styleUrls:['./new-post.component.css']
})

export class NewPostComponent {
    constructor(private postService: PostService) {}
	newSongs: any;
	ngOnInit() {
		this.postService.getNewSongs().subscribe(res => {
			console.log(res);
			this.newSongs = res;
		});
	}
}