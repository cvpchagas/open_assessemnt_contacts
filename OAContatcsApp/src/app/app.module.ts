import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactDatailsComponent } from './contact-datails/contact-datails.component';
import { ContactDatailFormComponent } from './contact-datails/contact-datail-form/contact-datail-form.component';
// Import HttpClientModule from @angular/common/http in AppModule
import {HttpClientModule} from '@angular/common/http';
//in place where you wanted to use `HttpClient`
import { HttpClient } from '@angular/common/http';
@NgModule({
  declarations: [
    AppComponent,
    ContactDatailsComponent,
    ContactDatailFormComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
