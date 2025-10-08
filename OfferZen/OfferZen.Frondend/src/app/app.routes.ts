import { Routes } from '@angular/router';
import { ProductListComponent } from './components/product/product-list/product-list.component';
import { ProductAddComponent } from './components/product/product-add/product-add.component';

export const routes: Routes = [
     { path: '', component: ProductListComponent },
     { path: 'products/add', component: ProductAddComponent },
     { path: '**', redirectTo: '' } // fallback
];
