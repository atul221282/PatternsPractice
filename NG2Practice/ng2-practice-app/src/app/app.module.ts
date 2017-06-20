import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { DurationPipe, SearchComponent, TOASTR_TOKEN, Toastr } from './';

declare let toastr: Toastr;

@NgModule({
    declarations: [
        AppComponent,
        DurationPipe,
        SearchComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    providers: [
        { provide: TOASTR_TOKEN, useValue: toastr }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
