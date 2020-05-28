import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { PopoverModule } from 'ngx-bootstrap/popover';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { NetworkComponent } from './network/network.component';
import { HttpClientModule } from '@angular/common/http';


@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      NetworkComponent
   ],
   imports: [
      BrowserModule,
      FormsModule,
      HttpClientModule,
      BrowserAnimationsModule,
      PopoverModule.forRoot(),
      ModalModule.forRoot(),
      TooltipModule.forRoot()
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
