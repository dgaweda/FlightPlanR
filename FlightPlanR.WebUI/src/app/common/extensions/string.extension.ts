interface String {
  setId(id: string): string;
}

String.prototype.setId = function(id: string): string {
  return String(this).replace(':id', id);
}
