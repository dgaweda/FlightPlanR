import {Component, OnInit} from '@angular/core';
import {BaseComponent} from "../../common/base.component";
import {LoaderService} from "../../services/loader.service";

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss']
})
export class LoaderComponent extends BaseComponent implements OnInit {
  protected isLoading: boolean;

  constructor(private loaderService: LoaderService) {
    super();
    this.isLoading = false;
  }

  ngOnInit(): void {
    this.subscribe(this.loaderService.getLoaderState(), {
      next: (state: boolean) => this.isLoading = state
    });
  }
}
