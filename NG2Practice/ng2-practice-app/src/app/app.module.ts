import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import {
    DurationPipe, SearchComponent,
    TOASTR_TOKEN, Toastr,
    JQUERY_TOKEN
} from './';

let toastr: Toastr = window['toastr'];
let $: any = window['$'];

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
        { provide: TOASTR_TOKEN, useValue: toastr },
        { provide: JQUERY_TOKEN, useValue: $ }
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }