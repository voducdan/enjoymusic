import { Component } from '@angular/core';

import { NavService } from './nav.services';

@Component({
	selector: 'nav-bar',
	templateUrl: './nav.component.html',
	styleUrls: ['./nav.component.css'],
})
export class NavComponent {
	constructor(private navService: NavService) {}

	categories: any;
	ngOnInit() {
		this.navService.getAllCategories().subscribe(res => {
			this.categories = res;
		});
	}
}
