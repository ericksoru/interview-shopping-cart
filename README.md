# Interview - Shopping Cart

In order to simulate a shopping cart, we need to implement all missing methods in `CartService`.

## What you need to do

Please implement all not implemented methods in `CartService`:

- AddProduct
- DeleteProduct
- ExistsProduct

Make sure all the tests are passing. Please write some tests for:

- DeleteProduct
  - Actual delete an existing product;
  - Try to delete an unexisting product (should );

- ExistsProduct (all overloads)
  - A product that exists;
  - A product that doesn't exist;
  - An invalid input (negative numbers, null, empty object);

## Architecture

The architecture of the project is quite simple:

- Rezult.Interviews.ShoppingCart.Core
- Rezult.Interviews.ShoppingCart.Entities
- Rezult.Interviews.ShoppingCart.Services

### Rezult.Interviews.ShoppingCart.Core

All the core methods, helpers and interfaces to make the project contracts.

### Rezult.Interviews.ShoppingCart.Entities

All the default entities that this project needs:

- Cart
- Product
- Category

### Rezult.Interviews.ShoppingCart.Services

The services implementations.
