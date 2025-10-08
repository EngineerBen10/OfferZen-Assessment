import { Component } from '@angular/core';

import { CategoryListComponent } from './components/category/category-list/category-list.component';
import { HttpClientModule } from '@angular/common/http';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { ProductAddComponent } from './components/product/product-add/product-add.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterModule],

  template:`<div class="app-container">
              <h1>OfferZen Product Management</h1>        
                <router-outlet></router-outlet>
              
            <!-- <section>
                <h2>Categories</h2>
                <app-category-list></app-category-list>
            </section> -->

            </div>`,
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'OfferZen.Frondend';
}
