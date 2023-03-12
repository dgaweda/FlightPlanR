import {AccordionModule} from "primeng/accordion";
import {NgModule} from "@angular/core";
import {BrowserModule} from "@angular/platform-browser";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {MenubarModule} from "primeng/menubar";
import {ButtonModule} from "primeng/button";
import {InputTextModule} from "primeng/inputtext";
import {CardModule} from "primeng/card";
import {MenuModule} from "primeng/menu";
import {MegaMenuModule} from "primeng/megamenu";
import {ToastModule} from "primeng/toast";

@NgModule({
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AccordionModule,
    MenubarModule,
    ButtonModule,
    InputTextModule,
    CardModule,
    MenuModule,
    MegaMenuModule,
    ToastModule
  ],
  exports: [
    BrowserModule,
    BrowserAnimationsModule,
    AccordionModule,
    MenubarModule,
    ButtonModule,
    InputTextModule,
    CardModule,
    MenuModule,
    MegaMenuModule,
    ToastModule
  ]
})
export class PrimeNgComponentsModule { }
