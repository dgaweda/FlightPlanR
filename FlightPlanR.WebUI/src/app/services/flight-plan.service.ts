import {Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";
import {BaseApiService} from "./base.service";
import {Observable} from "rxjs";
import {FlightPlan} from "../models/flight-plan.model";

@Injectable()
export class FlightPlanService extends BaseApiService{
  constructor(http: HttpClient) {
    super(http);
  }

  getAll(): Observable<FlightPlan[]> {
    return this.get(this.apiRoutes.flightPlan.getAll);
  }

  getById(id: string): Observable<FlightPlan> {
    return this.get(this.apiRoutes.flightPlan.getById.replace(':id', id));
  }

  addFlightPlan(flightPlan: FlightPlan): Observable<void> {
    return this.post(this.apiRoutes.flightPlan.add, flightPlan);
  }

  updateFlightPlan(id: string, flightPlan: FlightPlan): Observable<void> {
    return this.put(this.apiRoutes.flightPlan.update.replace(':id', id), flightPlan);
  }

  removeFlightPlan(id: string): Observable<void> {
    return this.delete(this.apiRoutes.flightPlan.remove.replace(':id', id));
  }

  getFlightPlanRoute(id: string): Observable<string> {
    return this.get(this.apiRoutes.flightPlan.getFlightPlanRoute.replace(':id', id));
  }

  getFlightPlanTimeEnroute(id: string): Observable<string> {
    return this.get(this.apiRoutes.flightPlan.getFlightPlanEnroute.replace(':id', id));
  }
}
