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
    getAll: `flightPlan`,
    getById: `flightPlan/${ID_KEY}`,
    add: `flightPlan`,
    update: `flightPlan/${ID_KEY}`,
    remove: `flightPlan/${ID_KEY}`,
    getFlightPlanEnroute: `flightPlan/route/time/${ID_KEY}`
  }
}
