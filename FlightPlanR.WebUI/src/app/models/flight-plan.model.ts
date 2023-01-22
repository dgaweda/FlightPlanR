export interface FlightPlan {
  id: string;
  aircraftIdentification: string;
  aircraftSpeed: string;
  airSpeed: number;
  altitude: number;
  flightType: string;
  fuelHours: number;
  fuelMinutes: number;
  departureTime: Date;
  arrivalTime: Date;
  departureAirport: string;
  arrivalAirport: string;
  route: string;
  remarks: string;
  numberOnBoard: number;
}
