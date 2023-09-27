import { Component, OnInit } from '@angular/core';
import {FlightPlanService} from "../../services/flight-plan.service";
import {FlightPlan} from "../../models/flight-plan.model";
import {BaseComponent} from "../../common/base.component";

@Component({
  selector: 'app-flight-plans',
  templateUrl: './flight-plans.component.html',
  styleUrls: ['./flight-plans.component.scss']
})
export class FlightPlansComponent extends BaseComponent implements OnInit {
  protected flightPlans: FlightPlan[];
  constructor(private flightPlanService: FlightPlanService) {
    super();
    this.flightPlans = [];
  }

  ngOnInit(): void {
    this.getFlightPlans();
  }

  private getFlightPlans(): void {
    this.subscribe(this.flightPlanService.getAll(), {
      next: (flightPlans: FlightPlan[]) => this.flightPlans = flightPlans
    })
  }
}
