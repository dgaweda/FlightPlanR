import {environment} from "../environments/environment";
import {ID_KEY} from "./common/constants";

export const ApiRoutes = {
  baseUrl: `${environment.baseApiRoute}`,
  account: {
    authenticate: `account/authenticate`,
    register: `account/register`
  },
  user: {
    getById: `user/${ID_KEY}`,
    getByUserName: `user`,
    update: `user/${ID_KEY}`,
    remove: `user/${ID_KEY}`
  },
  flightPlan: {
    getAll: `flight-plan`,
    getById: `flight-plan/${ID_KEY}`,
    add: `flight-plan`,
    update: `flight-plan/${ID_KEY}`,
    remove: `flight-plan/${ID_KEY}`,
    getFlightPlanEnroute: `flight-plan/route/time/${ID_KEY}`
  }
}
