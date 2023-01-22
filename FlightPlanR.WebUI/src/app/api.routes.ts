import {environment} from "../environments/environment";

export const ApiRoutes = {
  baseUrl: `${environment.baseApiRoute}`,
  authenticate: 'authenticate',
  user: {
    register: 'user/register',
    getById: 'user/:id',
    getByUserName: 'user',
    update: 'user/:id',
    remove: 'user/:id'
  },
  flightPlan: {
    getAll: 'flightPlan',
    getById: 'flightPlan/:id',
    add: 'flightPlan',
    update: 'flightPlan/:id',
    remove: 'flightPlan/:id',
    getFlightPlanRoute: 'flightPlan/route/:id',
    getFlightPlanEnroute: 'flightPlan/route/time/:id'
  }
}
