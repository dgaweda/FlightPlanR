import {environment} from "../environments/environment";

export const ApiRoutes = {
  baseUrl: `${environment.baseApiRoute}`,
  account: {
    authenticate: 'authenticate',
    register: 'register'
  },
  user: {
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
    getFlightPlanEnroute: 'flightPlan/route/time/:id'
  }
}
