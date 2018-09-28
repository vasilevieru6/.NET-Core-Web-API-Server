using OnlineShop.Architecture.ViewMoldels;
using OnlineShop.Models.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Architecture.Services
{
    public interface ICartService
    {
        IList<CartItemViewModel> GetAllProducts();
        void SetCartItemQuantity(ShoppingCartItem shoppingCartItem);
        void AddProductToCart(ShoppingCartItem shoppingCartItem);
    }
}
