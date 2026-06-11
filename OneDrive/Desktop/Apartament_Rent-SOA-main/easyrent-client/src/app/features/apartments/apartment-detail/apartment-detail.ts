import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { ApartmentService } from '../../../core/services/apartment';
import { AuthService } from '../../../core/services/auth';
import { Apartment } from '../../../core/models/apartment';

@Component({
  selector: 'app-apartment-detail',
  standalone: true,
  imports: [CommonModule, RouterModule, MatButtonModule, MatIconModule, MatCardModule],
  templateUrl: './apartment-detail.html',
  styleUrl: './apartment-detail.scss'
})
export class ApartmentDetailComponent implements OnInit {
  apartment: Apartment | undefined;

  // 👇 ALL 4 ORIGINAL APARTMENTS RESTORED PERFECTLY 👇
  private fallbackApartments: Apartment[] = [
    {
      id: 1,
      title: 'Riverside Studio, Skopje Center',
      description: 'A beautiful, sunlit studio apartment right near the Vardar River in the heart of the city center. Fully furnished with high-end appliances, smart home controls, and high-speed fiber internet.',
      price: 380,
      location: 'Skopje Center',
      rooms: 1,
      sqft: 45,
      landlordName: 'Elena Kostova',
      imageUrl: 'https://images.unsplash.com/photo-1522708323590-d24dbb6b0267?w=800'
    },
    {
      id: 2,
      title: 'Traditional Tetovo Duplex',
      description: 'Renovated duplex featuring beautiful dark wood beams, a cozy brick fireplace, and large windows looking out toward the Shar Mountains.',
      price: 550,
      location: 'Tetovo',
      rooms: 3,
      sqft: 110,
      landlordName: 'Bekim Halimi',
      imageUrl: 'https://images.unsplash.com/photo-1502672260266-1c1ef2d93688?w=800'
    },
    {
      id: 3,
      title: 'Charming Flat in Debar Maalo',
      description: 'Vibrant and contemporary flat located in Skopje’s most famous bohemian neighborhood. Steps away from the best cafes, traditional restaurants, and the Central City Park.',
      price: 450,
      location: 'Debar Maalo, Skopje',
      rooms: 2,
      sqft: 70,
      landlordName: 'Marija Angelova',
      imageUrl: 'https://images.unsplash.com/photo-1512917774080-9991f1c4c750?w=800'
    },
    {
      id: 4,
      title: 'Minimalist Retreat, Karposh',
      description: 'Sleek, minimalist design meets modern comfort in this highly desirable Karposh residential zone. Features central climate control and automated roller shades.',
      price: 410,
      location: 'Karposh, Skopje',
      rooms: 2,
      sqft: 65,
      landlordName: 'Stefan Ristovski',
      imageUrl: 'https://images.unsplash.com/photo-1600585154340-be6161a56a0c?w=800'
    }
  ];

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private apartmentService: ApartmentService,
    public authService: AuthService
  ) {}

  ngOnInit(): void {
    const idParam = this.route.snapshot.paramMap.get('id');
    if (idParam) {
      const targetId = +idParam;
      this.useFallback(targetId);
    }
  }

  private useFallback(id: number): void {
    this.apartment = this.fallbackApartments.find(apt => apt.id === id);
  }

  hasAlreadyApplied(): boolean {
    if (!this.apartment) return false;
    const savedData = localStorage.getItem('easyrent_lease_applications');
    if (!savedData) return false;
    
    const bookings: any[] = JSON.parse(savedData);
    const currentUserEmail = localStorage.getItem('active_user_email') || 'besiana771@gmail.com';
    return bookings.some(b => b.apartmentTitle === this.apartment?.title && b.tenantEmail === currentUserEmail);
  }

  onBookRequest(): void {
    if (!this.apartment) return;

    if (this.hasAlreadyApplied()) {
      return;
    }

    const currentUserEmail = localStorage.getItem('active_user_email') || 'besiana771@gmail.com';

    const newApplication = {
      id: Date.now(),
      tenantEmail: currentUserEmail,
      apartmentTitle: this.apartment.title,
      location: this.apartment.location,
      monthlyRent: this.apartment.price,
      status: 'Pending',
      requestDate: new Date().toISOString().split('T')[0]
    };

    const existingBookingsString = localStorage.getItem('easyrent_lease_applications');
    const existingBookings = existingBookingsString ? JSON.parse(existingBookingsString) : [];
    
    existingBookings.push(newApplication);
    localStorage.setItem('easyrent_lease_applications', JSON.stringify(existingBookings));

    alert(`Application for "${this.apartment.title}" sent to Landlord!`);
    this.router.navigate(['/my-bookings']);
  }
}