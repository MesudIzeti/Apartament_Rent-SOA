export interface Apartment {
  id: number;
  title: string;
  description: string;
  price: number;
  location: string;
  rooms: number;
  sqft: number; // Add this field
  landlordName?: string; // Add this optional field
  imageUrl: string;
}