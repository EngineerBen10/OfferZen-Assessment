import { Injectable } from "@angular/core";
import { environment } from "../enviroments/environment";
import { HttpClient, HttpParams } from "@angular/common/http";
import { PaginatedResult } from "../models/pagination-result.model";
import { Observable } from "rxjs/internal/Observable";
import { ProductDto } from "../models/product-dto.model";
import { Product } from "../models/product.model";

@Injectable({
    providedIn: 'root'
})
export class ProductService {
    private apiUrl = environment.apiUrl;


    constructor(private http: HttpClient) { }

    getProducts(pageNumber = 1, pageSize = 10, searchTerm = '', categoryName = '', productName = ''): Observable<PaginatedResult<ProductDto>> {
        let params = new HttpParams()
            .set('pageNumber', pageNumber)
            .set('pageSize', pageSize)
            .set('categoryName', categoryName)
            .set('productName', productName)
            .set('search', searchTerm);

        return this.http.get<PaginatedResult<ProductDto>>(`${this.apiUrl}/api/products`, { params });
    }

    getProduct(id: number): Observable<Product> {
        return this.http.get<Product>(`${this.apiUrl}/api/products/${id}`);
    }

    addProduct(product: Product): Observable<Product> {
        return this.http.post<Product>(`${this.apiUrl}/api/products`, product);
    }

    updateProduct(id: number, product: Product): Observable<void> {
        return this.http.put<void>(`${this.apiUrl}/api/products/${id}`, product);
    }

    deleteProduct(id: number): Observable<boolean> {
    return this.http.delete<boolean>(`${this.apiUrl}/api/products/${id}`,);
  }
}