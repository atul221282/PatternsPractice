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

declare let toastr: Toastr;
declare let $: any;

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
        { provide: TOASTR_TOKEN, useFactory: () => { return toastr; } },
        { provide: JQUERY_TOKEN, useValue: $ }
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }