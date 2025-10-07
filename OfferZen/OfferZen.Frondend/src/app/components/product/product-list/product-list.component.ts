import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../../services/product.service';
import { ProductDto } from '../../../models/product-dto.model';
import { Product } from '../../../models/product.model';
import { PaginatedResult } from '../../../models/pagination-result.model';
import { FormsModule } from '@angular/forms';
import { RouterLink } from '@angular/router';
import { ProductSearchComponent } from '../product-search/product-search.component';
import { ProductAddComponent } from '../product-add/product-add.component';

@Component({
  selector: 'app-product-list',
  standalone: true,
  imports: [CommonModule, RouterLink, FormsModule, ProductSearchComponent],
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss'
})
export class ProductListComponent implements OnInit {
   
     products: ProductDto[] = [];
      totalCount = 0;
      pageNumber = 1;
      pageSize = 10;     
      totalPages = 1;
      searchTerm = '';
      categoryName = '';
      productName = '';
      loading = false;
      errorMessage = '';

    constructor(private productService: ProductService) {}

    ngOnInit(): void {
         this.loadProducts();
    }
  
     loadProducts(): void {
    this.productService.getProducts(this.pageNumber, this.pageSize, this.searchTerm,this.categoryName, this.productName).subscribe({
      next: (result: PaginatedResult<ProductDto>) => {
        this.products = result.items;
        this.totalCount = result.totalCount;
        this.totalPages = Math.ceil(this.totalCount / this.pageSize);
        this.loading = false;
      },
      error: () => this.errorMessage = 'Error loading products'
    });

  }

 onSearch(term: string): void {
    this.searchTerm = term;
    this.pageNumber = 1;
    this.loadProducts();
  }


 deleteProduct(id: number): void {
    if (confirm('Are you sure you want to delete this product?')) {
      this.productService.deleteProduct(id).subscribe({
        next: () => this.loadProducts(),
        error: () => alert('Failed to delete product.')
      });
    }
  }

  nextPage(): void {
    if (this.pageNumber * this.pageSize < this.totalCount) {
      this.pageNumber++;
      this.loadProducts();
    }
  }

    prevPage(): void {
    if (this.pageNumber > 1) {
      this.pageNumber--;
      this.loadProducts();
    }
  }
}
