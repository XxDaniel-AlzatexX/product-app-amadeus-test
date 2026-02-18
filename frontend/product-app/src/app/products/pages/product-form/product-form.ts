import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatNativeDateModule } from '@angular/material/core';
import { MatCardModule } from '@angular/material/card';
import { ProductService } from '../../services/product.service';

@Component({
  selector: 'app-product-form',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatCheckboxModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatCardModule
  ],
  templateUrl: './product-form.html'
})

export class ProductFormComponent {

  private fb = inject(FormBuilder);
  private service = inject(ProductService);
  private router = inject(Router);

  form = this.fb.group({
    name: ['', Validators.required],
    description: ['', Validators.required],
    price: [0, [Validators.required, Validators.min(0.01)]],
    stock: [0, [Validators.required, Validators.min(0)]],
    category: ['', Validators.required],
    expirationDate: ['', Validators.required],
    isActive: [true]
  });

  save() {
  if (this.form.invalid) {
    this.form.markAllAsTouched();
    return;
  }
  this.service.create(this.form.value)
    .subscribe({
      next: () => {
        this.router.navigate(['/'], {
          state: { refresh: true }
        });
      }
    });
  }

  goBack() {
    this.router.navigate(['/'], {
      state: { refresh: true }
    });
  }

}
