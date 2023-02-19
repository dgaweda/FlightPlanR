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
    return this.get(this.apiRoutes.flightPlan.getById.setApiRouteId(id));
  }

  addFlightPlan(flightPlan: FlightPlan): Observable<void> {
    return this.post(this.apiRoutes.flightPlan.add, flightPlan);
  }

  updateFlightPlan(id: string, flightPlan: FlightPlan): Observable<void> {
    return this.put(this.apiRoutes.flightPlan.update.setApiRouteId(id), flightPlan);
  }

  removeFlightPlan(id: string): Observable<void> {
    return this.delete(this.apiRoutes.flightPlan.remove.setApiRouteId(id));
  }

  getFlightPlanTimeEnroute(id: string): Observable<string> {
    return this.get(this.apiRoutes.flightPlan.getFlightPlanEnroute.setApiRouteId(id));
  }
}
