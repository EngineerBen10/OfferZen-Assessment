import { Category } from "./category.model";

export interface Product {
  id: number;
  name: string;
  description: string;
  sku: string; // Guid from backend
  price: number;
  quantity: number;
  categoryId: number;
  createdAt: Date;
}