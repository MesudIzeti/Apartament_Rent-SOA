export interface Booking {
  id: number;
  apartmentId: number;
  userId: string;
  startDate: string; // Using string for ISO Date format compatibility with JSON
  endDate: string;
  totalPrice: number;
}
