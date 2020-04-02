import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule} from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import {
	HomeComponent,
	NewPostComponent,
	ListenComponent,
	NewPostThumnailComponent,
	PostService,
} from './Home/index';

@NgModule({
	declarations: [
		AppComponent,
		NavComponent,
		HomeComponent,
		NewPostComponent,
		ListenComponent,
		NewPostThumnailComponent,
	],
	imports: [BrowserModule, AppRoutingModule, HttpClientModule],
	providers: [PostService ],
	bootstrap: [AppComponent],
})
export class AppModule {}
