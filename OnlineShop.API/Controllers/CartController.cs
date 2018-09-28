using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Architecture.Services;
using OnlineShop.Architecture.ViewMoldels;
using OnlineShop.Models.Domain;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    public class CartController : Controller
    {
        private readonly IMapper _mapper;
        private ICartService _cartService;
        public CartController(ICartService cartService, IMapper mapper)
        {
            _mapper = mapper;
            _cartService = cartService;
        }
        
        [HttpGet("products")]
        public IList<CartItemViewModel> GetAllProducts()
        {
            return _cartService.GetAllProducts();
        }

        [HttpPatch("cartItem/{id}")]
        public IActionResult SetCartItemQuantity([FromBody] QuantityCartItemViewModel quantityCartItemViewModel, long id)
        {
            var cartItem = _mapper.Map<QuantityCartItemViewModel, ShoppingCartItem>(quantityCartItemViewModel);
            _cartService.SetCartItemQuantity(cartItem);

            return Json(quantityCartItemViewModel);
        }

        [HttpPost("product")]
        public IActionResult CreateCartItem([FromBody] QuantityCartItemViewModel cartItemViewModel)
        {
            var cartItem = _mapper.Map<QuantityCartItemViewModel, ShoppingCartItem>(cartItemViewModel);
            _cartService.AddProductToCart(cartItem);
            return Json(cartItemViewModel);
        }
    }
}