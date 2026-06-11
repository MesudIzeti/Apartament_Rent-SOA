import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { ApartmentService } from '../../../core/services/apartment';
import { Apartment } from '../../../core/models/apartment';

@Component({
  selector: 'app-apartment-list',
  standalone: true,
  imports: [CommonModule, RouterModule, MatCardModule, MatButtonModule, MatIconModule],
  templateUrl: './apartment-list.html',
  styleUrl: './apartment-list.scss'
})
export class ApartmentListComponent implements OnInit {
  apartments: Apartment[] = [];

  // Localized data dictionary featuring North Macedonia properties matching your template design
  fallbackApartments: Apartment[] = [
    {
      id: 1,
      title: 'Riverside Studio, Skopje Center',
      description: 'A beautiful, sunlit studio apartment right near the Vardar River in the heart of the city center. Fully furnished with high-end appliances, smart home controls, and high-speed fiber internet. Perfect for students or young professionals looking to stay connected to everything the city has to offer.',
      price: 380,
      location: 'Skopje Center',
      rooms: 1,
      sqft: 45,
      landlordName: 'Elena Kostova',
      imageUrl: 'https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?w=500'
    },
    {
      id: 2,
      title: 'Traditional Tetovo Duplex',
      description: 'Renovated duplex featuring beautiful dark wood beams, a cozy brick fireplace, and large windows looking out toward the Shar Mountains. Features a newly remodeled bathroom, a large open-concept kitchen layout, private storage cellars, and a beautiful quiet balcony.',
      price: 550,
      location: 'Tetovo',
      rooms: 3,
      sqft: 110,
      landlordName: 'Bekim Halimi',
      imageUrl: 'https://images.unsplash.com/photo-1502672260266-1c1ef2d93688?w=500'
    },
    {
      id: 3,
      title: 'Charming Flat in Debar Maalo',
      description: 'Vibrant and contemporary flat located in Skopje’s most famous bohemian neighborhood. Steps away from the best cafes, traditional restaurants, and the Central City Park. Includes premium hardwood flooring, a fully equipped kitchen, and high-speed Wi-Fi.',
      price: 450,
      location: 'Debar Maalo, Skopje',
      rooms: 2,
      sqft: 70,
      landlordName: 'Marija Angelova',
      imageUrl: 'https://images.unsplash.com/photo-1512917774080-9991f1c4c750?w=500'
    },
    {
      id: 4,
      title: 'Minimalist Retreat, Karposh',
      description: 'Sleek, minimalist design meets modern comfort in this highly desirable Karposh residential zone. Features central climate control, automated roller shades, custom recessed ambient lighting fixtures, and direct access to secure private basement parking facilities.',
      price: 410,
      location: 'Karposh, Skopje',
      rooms: 2,
      sqft: 65,
      landlordName: 'Stefan Ristovski',
      imageUrl: 'https://images.unsplash.com/photo-1600585154340-be6161a56a0c?w=500'
    }
  ];

  constructor(private apartmentService: ApartmentService) {}

  ngOnInit(): void {
    // FORCED TEST: Load local data instantly so pictures show up regardless of the empty API tables
    this.apartments = this.fallbackApartments;
    console.log('Temporarily bypassed API to display fallback grid cards layout immediately');

    /* Commenting out active backend database stream until tables contain data matching these schema IDs
    this.apartmentService.getApartments().subscribe({
      next: (data: Apartment[]) => {
        this.apartments = (data && data.length > 0) ? data : this.fallbackApartments;
      },
      error: (err: any) => {
        console.error('Failed to load apartments from API', err);
        this.apartments = this.fallbackApartments;
      }
    });
    */
  }
}