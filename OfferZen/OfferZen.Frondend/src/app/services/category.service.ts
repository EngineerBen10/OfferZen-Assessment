import { HttpClient } from "@angular/common/http";
import { Category } from "../models/category.model";
import { Observable } from "rxjs";
import { environment } from "../enviroments/environment";
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
    // Service methods would go here

    private apiUrl = environment.apiUrl;

    constructor(private http: HttpClient) {}

    getCategories(): Observable<Category[]> {
        return this.http.get<Category[]>(`${this.apiUrl}/api/categories`);
    }
}
