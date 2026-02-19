import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  private api = 'http://localhost:5168/api/products';

  constructor(private http: HttpClient) {}

  getAll() {
    return this.http.get<Product[]>(this.api);
  }

  getById(id: number){
    return this.http.get<Product>(`${this.api}/${id}`);
  }

  create(product: any) {
    return this.http.post(this.api, product);
  }

  update(id: number, product: any) {
    return this.http.put(`${this.api}/${id}`, product);
  }

  delete(id: number) {
    return this.http.delete(`${this.api}/${id}`);
  }
}
