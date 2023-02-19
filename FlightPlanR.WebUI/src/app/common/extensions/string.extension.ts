interface String {
  setApiRouteId(id: string): string;
}
String.prototype.setApiRouteId = function(id: string): string {
  return String(this).replace(':id', id);
}
