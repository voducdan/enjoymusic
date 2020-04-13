import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent, NavService } from './nav/index';
import {
	HomeComponent,
	NewPostComponent,
	NewPostThumnailComponent,
	CommentComponent,
	PostService,
	SongThumnailComponent,
	SongThumnailService
	
} from './Home/index';
import { Global } from './Global/global-variable';

@NgModule({
	declarations: [
		AppComponent,
		NavComponent,
		HomeComponent,
		NewPostComponent,
		NewPostThumnailComponent,
		CommentComponent,
		SongThumnailComponent
	],
	imports: [BrowserModule, AppRoutingModule, HttpClientModule],
	providers: [PostService, NavService,SongThumnailService, Global],
	bootstrap: [AppComponent],
})
export class AppModule {}
