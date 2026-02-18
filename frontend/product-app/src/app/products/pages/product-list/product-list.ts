import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavigationEnd, Router } from '@angular/router';
import { MatTableDataSource } from '@angular/material/table';
import { MatTableModule } from '@angular/material/table';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatCardModule } from '@angular/material/card';
import { ProductService } from '../../services/product.service';
import { Product } from '../../models/product';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [
    CommonModule,
    MatTableModule,
    MatButtonModule,
    MatIconModule,
    MatCardModule
  ],
  templateUrl: './product-list.html'
})

export class ProductListComponent implements OnInit {

  private service = inject(ProductService);
  private router = inject(Router);

  dataSource = new MatTableDataSource<Product>();

  displayedColumns = [
    'name',
    'price',
    'stock',
    'category',
    'isActive',
    'actions'
  ];

  ngOnInit() {
    this.load();
  }

  load() {
    this.service.getAll()
      .subscribe(data => {
        this.dataSource.data = data;
      });
  }

  create() {
    this.router.navigate(['/create']);
  }

  delete(id: number) {
    this.service.delete(id)
      .subscribe(() => this.load());
  }
}
