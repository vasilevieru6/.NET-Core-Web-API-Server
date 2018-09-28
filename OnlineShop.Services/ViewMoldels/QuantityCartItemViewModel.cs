using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Architecture.ViewMoldels
{
    public class QuantityCartItemViewModel : BaseViewModel
    {
        public int Quantity { get; set; } = 1;
        public long ProductId { get; set; }
        public long ShoppingCartId { get; set; }
    }
}
