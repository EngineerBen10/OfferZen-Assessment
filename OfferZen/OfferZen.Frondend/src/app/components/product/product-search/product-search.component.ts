import { Component, EventEmitter, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-product-search',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <input type="text" [(ngModel)]="searchTerm" placeholder="Search products..." />
    <button (click)="onSearch()">Search</button>
  `
})
export class ProductSearchComponent {
  @Output() search = new EventEmitter<string>();
  searchTerm = '';

  onSearch(): void {
    this.search.emit(this.searchTerm);
  }
}
