import { Component, OnInit } from '@angular/core';
import { Category } from '../../../models/category.model';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { ProductService } from '../../../services/product.service';
import { CategoryService } from '../../../services/category.service';
import { Product } from '../../../models/product.model';
import { get } from 'http';

@Component({
  selector: 'app-product-edit',
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './product-edit.component.html',
  styleUrl: './product-edit.component.scss'
})

export class ProductEditComponent implements OnInit {
  productForm!: FormGroup;
  categories: Category[] = [];
  product: Product = null!;
  productId!: number;
  errorMessage = '';
  successMessage = '';
  isSubmitting = false;

  constructor(private fb: FormBuilder,
    private route: ActivatedRoute,
    private productService: ProductService,
    private category: CategoryService,
    private router: Router) { }
  ngOnInit(): void {
    this.productId = this.route.snapshot.params['id'];
    this.initForm();
    this.getProduct();
    this.loadCategories();
  }

  private initForm(): void {
    this.productForm = this.fb.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      price: [0, [Validators.required, Validators.min(0)]],
      quantity: [0, [Validators.required, Validators.min(0)]],
    });

  }

  loadCategories(): void {
    this.category.getCategories().subscribe({
      next: (categories) => (this.categories = categories),
      error: (err) => (this.errorMessage = 'Failed to load categories'),
    });
  }

  getProduct(): void {
    this.productService.getProduct(this.productId).subscribe({
      next: (product) => (this.product = product),
      error: () => this.errorMessage = 'Error loading product',
    });

  }

  cancel(): void {
    this.router.navigate(['/products']);
  }

    onSubmit(): void {
    if (this.productForm.invalid) {
      this.errorMessage = 'Please fill in all required fields correctly.';
      return;
    }

    this.isSubmitting = true;
    this.errorMessage = '';
    this.successMessage = '';

    const newProduct: Product = {
      id: 0,
      ...this.productForm.value,
      createdAt: new Date(),
      updatedAt: this.product.updatedAt
    };

    this.productService.updateProduct(this.productId, newProduct).subscribe({
      next: () => {
        this.successMessage = 'Product added successfully!';
        setTimeout(() => this.router.navigate(['/products']), 1200);
      },
      error: () => {
        this.errorMessage = 'Failed to add product. Please try again.';
        this.isSubmitting = false;
      },
    });
  }
}
