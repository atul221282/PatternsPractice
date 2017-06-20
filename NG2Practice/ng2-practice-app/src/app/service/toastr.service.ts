import { Injectable, OpaqueToken } from '@angular/core';

let TOASTR_TOKEN = new OpaqueToken("token");

interface Toastr {
    success(msg: string, title?: string): void;
    error(msg: string, title?: string): void;
    info(msg: string, title?: string): void;
    warning(msg: string, title?: string): void;

}


export { TOASTR_TOKEN, Toastr };
