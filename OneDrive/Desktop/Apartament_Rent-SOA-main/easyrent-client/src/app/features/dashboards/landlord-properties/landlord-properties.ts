import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatTabsModule } from '@angular/material/tabs';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-landlord-properties',
  standalone: true,
  imports: [
    CommonModule, 
    ReactiveFormsModule,
    MatCardModule, 
    MatButtonModule, 
    MatIconModule, 
    MatTabsModule,
    MatFormFieldModule,
    MatInputModule
  ],
  templateUrl: './landlord-properties.html',
  styleUrl: './landlord-properties.scss'
})
export class LandlordPropertiesComponent implements OnInit {
  listingForm!: FormGroup;
  showCreateForm = false;

  myProperties = [
    { id: 1, title: 'Riverside Studio, Skopje Center', price: 380, views: 124 },
    { id: 3, title: 'Charming Flat in Debar Maalo', price: 450, views: 342 }
  ];

  incomingApplications: any[] = [];

  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    this.loadApplications();

    this.listingForm = this.fb.group({
      title: ['', [Validators.required, Validators.minLength(5)]],
      location: ['', Validators.required],
      price: ['', [Validators.required, Validators.min(1)]],
      rooms: ['', [Validators.required, Validators.min(1)]],
      sqft: ['', [Validators.required, Validators.min(1)]],
      imageUrl: [''],
      description: ['', [Validators.required, Validators.minLength(10)]]
    });
  }

  loadApplications(): void {
    const savedData = localStorage.getItem('easyrent_lease_applications');
    // Reads all submitted items across both user databases directly
    this.incomingApplications = savedData ? JSON.parse(savedData) : [];
  }

  toggleForm(): void {
    this.showCreateForm = !this.showCreateForm;
  }

  updateStatus(id: number, targetStatus: 'Approved' | 'Declined'): void {
    const savedData = localStorage.getItem('easyrent_lease_applications');
    let currentApplications = savedData ? JSON.parse(savedData) : [];

    currentApplications = currentApplications.map((app: any) => {
      if (app.id === id) {
        app.status = targetStatus;
      }
      return app;
    });

    localStorage.setItem('easyrent_lease_applications', JSON.stringify(currentApplications));
    this.loadApplications();
  }

  onSubmitListing(): void {
    if (this.listingForm.valid) {
      const newApartment = this.listingForm.value;
      this.myProperties.push({
        id: Date.now(),
        title: newApartment.title,
        price: newApartment.price,
        views: 0
      });
      alert(`"${newApartment.title}" has been added to your properties layout!`);
      this.listingForm.reset();
      this.showCreateForm = false;
    }
  }
}