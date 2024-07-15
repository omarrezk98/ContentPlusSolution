import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class CartService {
  private cartItems: any[] = [];

  constructor() {
    this.loadCartFromLocalStorage();
  }

  addToCart(product: any) {
    const existingProduct = this.cartItems.find(item => item.name === product.name);
    if (existingProduct) {
      existingProduct.quantity += 1;
    } else {
      product.quantity = 1;
      this.cartItems.push(product);
    }
    this.saveCartToLocalStorage();
  }

  getCartItems() {
    return this.cartItems;
  }

  updateQuantity(product: any, quantity: number) {
    const existingProduct = this.cartItems.find(item => item.name === product.name);
    if (existingProduct) {
      existingProduct.quantity = quantity;
      this.saveCartToLocalStorage();
    }
  }

  removeFromCart(product: any) {
    const index = this.cartItems.indexOf(product);
    if (index > -1) {
      this.cartItems.splice(index, 1);
      this.saveCartToLocalStorage();
    }
  }

  private saveCartToLocalStorage() {
    localStorage.setItem('cartItems', JSON.stringify(this.cartItems));
  }

  private loadCartFromLocalStorage() {
    const storedCartItems = localStorage.getItem('cartItems');
    if (storedCartItems) {
      this.cartItems = JSON.parse(storedCartItems);
    }
  }
}
