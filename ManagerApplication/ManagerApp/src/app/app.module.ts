import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FeedbackViewComponent } from './feedback/feedback-view/feedback-view.component';
import { FeedbackPublishComponent } from './feedback/feedback-publish/feedback-publish.component';
import { FeedbackService } from './feedback/feedback.service';

@NgModule({
  declarations: [
    AppComponent,
    FeedbackViewComponent,
    FeedbackPublishComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [FeedbackService],
  bootstrap: [AppComponent]
})
export class AppModule { }
