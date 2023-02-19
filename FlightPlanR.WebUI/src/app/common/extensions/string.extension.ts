String.prototype.setRouteId = function(id: string): string {
  return String(this).replace(':id', id);
}
