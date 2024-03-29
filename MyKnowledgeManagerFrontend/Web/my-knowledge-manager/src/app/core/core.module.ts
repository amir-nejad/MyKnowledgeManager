import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { MenuComponent } from './menu/menu.component';
import { CoreRoutingModule } from './core-routing.module';



@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent,
    MenuComponent
  ],
  imports: [
    CommonModule,
    CoreRoutingModule
  ],
  providers: [],
  exports: [
    HeaderComponent,
    FooterComponent
  ]
})
export class CoreModule { }
