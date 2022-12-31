import { NgModule, TemplateRef } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { MenuComponent } from './core/menu/menu.component';
import { CoreModule } from './core/core.module';
import { KnowledgeTagsModule } from './modules/knowledge-tags/knowledge-tags.module';
import { HttpClientModule } from '@angular/common/http';
import { KnowledgeModule } from './modules/knowledge/knowledge.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    KnowledgeTagsModule,
    KnowledgeModule,
    HttpClientModule,
    CoreModule,
    NgbModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
