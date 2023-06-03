import { NgModule, TemplateRef } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { CoreModule } from './core/core.module';
import { KnowledgeTagsModule } from './modules/knowledge-tags/knowledge-tags.module';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { KnowledgeModule } from './modules/knowledge/knowledge.module';
import { ErrorInterceptor } from './core/interceptors/error.interceptor';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    NgbModule,
    CoreModule,
    KnowledgeTagsModule,
    KnowledgeModule,
  ],
  providers: [
    ErrorInterceptor
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
