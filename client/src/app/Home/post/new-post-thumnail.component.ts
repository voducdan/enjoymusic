import { Component, Input } from '@angular/core';

@Component({
	selector: 'new-post-thumnail',
	templateUrl: './new-post-thumnail.component.html',
	styleUrls: ['./new-post-thumnail.component.css'],
})
export class NewPostThumnailComponent {
    @Input() song;
    
    ngOnInit(){
        console.log(this.song)
    }
}
