import { Component } from '@angular/core';

import { ListenService } from './listen.service';
import { Global } from 'src/app/Global/global-variable';
@Component({
	selector: 'listen',
	templateUrl: './listen.component.html',
	styleUrls: ['./listen.component.css'],
})
export class ListenComponent {
	constructor(private listenService: ListenService, private global:Global) {}

	topListen: any;
	ngOnInit() {
		this.listenService.getTopListen().subscribe(res => {
            this.topListen = res;
            this.topListen.forEach(item=>{
                item.avt = this.global.IMAGES_URL + item.avt
            })
		});
	}
}
