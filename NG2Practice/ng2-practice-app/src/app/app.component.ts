import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
    title = 'app works!';

    parentName = {
        name: "Atul"
    };
    firstName = "";

    ngOnInit() {
        this.parentName.name = "Atul";
        this.firstName = "Iha";
    }

    onChange(firstName: string) {
        this.firstName = firstName;
    }
}