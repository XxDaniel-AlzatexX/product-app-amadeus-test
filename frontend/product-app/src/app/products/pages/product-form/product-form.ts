import { Component, inject, OnInit } from '@angular/core';
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
import { ActivatedRoute } from '@angular/router';

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

export class ProductFormComponent implements OnInit{

  private fb = inject(FormBuilder);
  private service = inject(ProductService);
  private router = inject(Router);
  private route = inject(ActivatedRoute);

  isEditMode = false;
  productId: number | null = null;

  form = this.fb.group({
    name: ['', Validators.required],
    description: ['', Validators.required],
    price: [0, [Validators.required, Validators.min(0.01)]],
    stock: [0, [Validators.required, Validators.min(0)]],
    category: ['', Validators.required],
    expirationDate: [null as Date | null, Validators.required],
    isActive: [true]
  });

  ngOnInit(): void {
      const id = this.route.snapshot.paramMap.get('id');

      if (id){
        this.isEditMode = true;
        this.productId = +id;
        this.loadProduct(this.productId);
      }
  }

  save() {
  if (this.form.invalid) {
    this.form.markAllAsTouched();
    return;
  }
  if (this.isEditMode && this.productId !== null){
    this.service.update(this.productId, this.form.value)
      .subscribe(() => {
        this.router.navigate(['/']);
      });
  } else {
      this.service.create(this.form.value)
      .subscribe({
        next: () => {
          this.router.navigate(['/'], {
            state: { refresh: true }
          });
        }
      });
    }
  }

  goBack() {
    this.router.navigate(['/'], {
      state: { refresh: true }
    });
  }

  loadProduct(id: number){
    this.service.getById(id)
    .subscribe(product => {
      this.form.patchValue({
        name: product.name,
        description: product.description,
        price: product.price,
        stock: product.stock,
        category: product.category,
        expirationDate: product.expirationDate,
        isActive: product.isActive
      });
    });
  }

}
