import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FeedbackViewComponent } from './feedback-view/feedback-view.component';
import { FeedbackPublishComponent } from './feedback-publish/feedback-publish.component';

@NgModule({
  declarations: [
    AppComponent,
    FeedbackViewComponent,
    FeedbackPublishComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
