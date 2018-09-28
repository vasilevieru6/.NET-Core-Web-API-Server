using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OnlineShop.Architecture.ViewMoldels;
using OnlineShop.Models.Domain;
using OnlineShop.Repositorie;

namespace OnlineShop.Architecture.Services
{
    public class CartService : ICartService
    {

        private IRepository _repository;

        public CartService(IRepository repository)
        {
            _repository = repository;
        }
        public IList<CartItemViewModel> GetAllProducts()
        {
            IQueryable<ShoppingCartItem> shoppingCartItem = _repository.GetAll<ShoppingCartItem>();

            return shoppingCartItem
                .Where(x => x.ShoppingCart.UserId == 1)
                .Select(x => new CartItemViewModel
                {
                    Id = x.Id,
                    Name = x.Product.Name,
                    UnitPrice = x.Product.UnitPrice,
                    Description = x.Product.Description,
                    Quantity = x.Quantity,
                    ShoppingCartId = x.ShoppingCartId,
                    ProductId = x.ProductId
                })
                .ToList();
        }

        public void SetCartItemQuantity(ShoppingCartItem shoppingCartItem)
        {
            _repository.Update(shoppingCartItem);
        }


        public void AddProductToCart(ShoppingCartItem shoppingCartItem)
        {
            _repository.Add(shoppingCartItem);
        }
    }
}
