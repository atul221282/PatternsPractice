import { Component, OnInit, Inject } from '@angular/core';
import { TOASTR_TOKEN, Toastr } from '../service/toastr.service'

@Component({
    selector: 'app-search',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.css']
})

export class SearchComponent implements OnInit {

    constructor( @Inject(TOASTR_TOKEN) private toastr: Toastr) { }

    ngOnInit() {
    }

    search(searchForm: any) {
        this.toastr.error("OHH OOHH OOHH", "ERROR");
        console.log(searchForm);
    }
}
