import { Routes } from '@angular/router';
import { ProductFormComponent } from './products/pages/product-form/product-form';
import { ProductListComponent } from './products/pages/product-list/product-list';

export const routes: Routes = [
  { path: '', component: ProductListComponent },
  { path: 'create', component: ProductFormComponent }
];
