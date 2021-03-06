﻿import { Component, OnInit, Inject, Input, Output, EventEmitter } from '@angular/core';
import { TOASTR_TOKEN, Toastr } from '../service/toastr.service';
import { JQUERY_TOKEN } from '../service/jquery.service';

@Component({
    selector: 'app-search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.css']
})

export class SearchComponent implements OnInit {

    @Input() name: any;

    @Output() change = new EventEmitter<string>();

    constructor(
        @Inject(TOASTR_TOKEN) private toastr: Toastr,
        @Inject(JQUERY_TOKEN) private $: any
    ) { }

    ngOnInit() {
        let anchor = this.$("#someId");

        setTimeout(() => {
            this.toastr.warning("Ohh Ohh warning", "Warning");
            anchor.html("TIMEOUT");
        }, 5000);

        anchor.html("TEST");
    }

    search(searchForm: any) {
    }

    updateName() {
        this.name["name"] = "Kapil";
        this.change.emit('Ishana');
    }
}