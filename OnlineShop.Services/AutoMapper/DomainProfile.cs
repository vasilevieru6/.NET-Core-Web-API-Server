using AutoMapper;
using OnlineShop.Models.Domain;
using OnlineShop.Architecture.ViewMoldels;

namespace OnlineShop.Architecture.AutoMapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Product, CategoryAndSubCategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
            CreateMap<ProductViewModel, Product>();
            CreateMap<QuantityCartItemViewModel, ShoppingCartItem>();
        }
    }
}
