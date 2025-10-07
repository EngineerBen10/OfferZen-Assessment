export interface Category {
    id: number;
    name: string;  
    price: number;
    description?: string; 
    parentCategoryId: number | null;
}