import { Component, OnInit } from '@angular/core';
import { CartService } from './cart.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.scss'],
})
export class CartComponent implements OnInit {
  cartItems: any[] = [];

  constructor(private cartService: CartService) {}

  ngOnInit(): void {
    this.cartItems = this.cartService.getCartItems();
  }

  removeFromCart(item: any): void {
    this.cartService.removeFromCart(item);
    this.cartItems = this.cartService.getCartItems(); // تحديث العناصر المعروضة
  }

  updateQuantity(item: any, quantity: number): void {
    if (quantity > 0) {
      this.cartService.updateQuantity(item, quantity);
      this.cartItems = this.cartService.getCartItems(); // تحديث العناصر المعروضة
    }
  }
}
