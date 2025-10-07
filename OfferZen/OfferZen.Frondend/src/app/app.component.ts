import { Component } from '@angular/core';

import { CategoryListComponent } from './components/category/category-list/category-list.component';
import { HttpClientModule } from '@angular/common/http';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { ProductAddComponent } from './components/product/product-add/product-add.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CategoryListComponent, ProductListComponent],

  template:`<div class="app-container">
              <h1>OfferZen Product Management</h1>
                <app-product-list></app-product-list>
            <section>
                <h2>Categories</h2>
                <app-category-list></app-category-list>
            </section>

            </div>`,
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'OfferZen.Frondend';
}
