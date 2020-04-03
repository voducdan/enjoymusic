import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent, NavService } from './nav/index';
import {
	HomeComponent,
	NewPostComponent,
	ListenComponent,
	NewPostThumnailComponent,
	SuggestComponent,
	CommentComponent,
	DownloadComponent,
	PostService,
	ListenService,
} from './Home/index';
import { Global } from './Global/global-variable';

@NgModule({
	declarations: [
		AppComponent,
		NavComponent,
		HomeComponent,
		NewPostComponent,
		ListenComponent,
		NewPostThumnailComponent,
		SuggestComponent,
		CommentComponent,
		DownloadComponent,
	],
	imports: [BrowserModule, AppRoutingModule, HttpClientModule],
	providers: [PostService, NavService, ListenService, Global],
	bootstrap: [AppComponent],
})
export class AppModule {}
