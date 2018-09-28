using OnlineShop.Architecture.ViewMoldels;
using OnlineShop.Models.Domain;
using System.Collections.Generic;

namespace OnlineShop.Architecture.Services
{
    public interface IProductService
    {
        IEnumerable<CategoryAndSubCategoryViewModel> GetProductCategoriesAndSubCategories();
        IList<ProductViewModel> GetInfoAboutProducts(string category, string subCategory);
        IList<ProductViewModel> GetAllProducts();
        void CreateProduct(Product product);
        IEnumerable<CategoryViewModel> GetProductCategories(string category);
        IEnumerable<SubCategoryViewModel> GetProductSubCategories(string subCategory);
    }
}
