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
import {ProgressSpinnerModule} from "primeng/progressspinner";
import {ProgressBarModule} from "primeng/progressbar";
import {TableModule} from "primeng/table";

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
    ToastModule,
    ProgressSpinnerModule,
    ProgressBarModule,
    TableModule
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
    ToastModule,
    ProgressSpinnerModule,
    ProgressBarModule,
    TableModule
  ]
})
export class PrimeNgComponentsModule { }
