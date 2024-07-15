import { Component } from '@angular/core';
import { CartService } from '../cart/cart.service';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrl: './product-card.component.scss',
})
export class ProductCardComponent {
  products = [
    {
      name: 'Hollow Cement Block',
      size: '20*20*40 CM',
      price: '$20',
      image: 'assets/images/block1.jpeg',
    },
    {
      name: 'Hollow Cement Block',
      size: '15*20*20 CM',
      price: '$18',
      image: 'assets/images/block3.jpeg',
    },
    {
      name: 'Hollow Cement Block',
      size: '10*10*20 CM',
      price: '$15',
      image: 'assets/images/block2.jpeg',
    },
    {
      name: 'Fluted Cement Block',
      size: '20*20*40 CM',
      price: '$25',
      image: 'assets/images/block4.jpeg',
    },
    {
      name: 'Fluted Cement Block',
      size: '10*10*20 CM',
      price: '$23',
      image: 'assets/images/block8.jpeg',
    },
    {
      name: 'Solid Cement Block',
      size: '20*20*40 CM',
      price: '$28',
      image: 'assets/images/block6.jpeg',
    },
    {
      name: 'Solid Cement Block',
      size: '15*20*20 CM',
      price: '$26',
      image: 'assets/images/block5.jpeg',
    },
    {
      name: 'Solid Cement Block',
      size: '10*20*20 CM',
      price: '$17',
      image: 'assets/images/block7.jpeg',
    },
    {
      name: 'Hourdy Cement Block',
      size: '40*20*20*38 CM',
      price: '$30',
      image: 'assets/images/block10.jpeg',
    },
    {
      name: 'Hourdy Cement Block',
      size: '40*20*25*38 CM',
      price: '$28',
      image: 'assets/images/block9.jpeg',
    },
    {
      name: 'Insulated Block',
      size: '20*20*40 CM',
      price: '$24',
      image: 'assets/images/block12.jpeg',
    },
    {
      name: 'Insulated Block',
      size: '10*10*40 CM',
      price: '$14',
      image: 'assets/images/block11.jpeg',
    },
  ];

  constructor(private cartService: CartService) {}

  onCardClick(product: any) {
    this.cartService.addToCart(product);
  }
}
