import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CategoryListComponent } from './components/category/category-list/category-list.component';
import { HttpClientModule } from '@angular/common/http';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CategoryListComponent,

           ],
  template:`<div class="app-container">
              <h1>OfferZen Product Management</h1>
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
