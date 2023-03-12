import {ID_KEY} from "../constants";

String.prototype.setRouteId = function(id: string): string {
  return String(this).replace(ID_KEY, id);
}
