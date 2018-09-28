using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Architecture.Services;
using OnlineShop.Architecture.ViewMoldels;
using OnlineShop.Models.Domain;
using System.Collections.Generic;

namespace OnlineShop.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IMapper _mapper;
        private IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        //GET api/values
        [HttpGet("categoriesAndSubCategories")]
        public IEnumerable<CategoryAndSubCategoryViewModel> GetProductCategoriesAndSubCategories()
        {
            IEnumerable<CategoryAndSubCategoryViewModel> categories = _productService.GetProductCategoriesAndSubCategories();
            return categories;
        }

        [HttpGet("categories/{category}")]
        public IEnumerable<CategoryViewModel> GetProductCategories(string category)
        {
            IEnumerable<CategoryViewModel> categories = _productService.GetProductCategories(category);
            return categories;
        }

        [HttpGet("subCategories/{subCategory}")]
        public IEnumerable<SubCategoryViewModel> GetProductSubCategories(string subCategory)
        {
            IEnumerable<SubCategoryViewModel> subCategories = _productService.GetProductSubCategories(subCategory);
            return subCategories;
        }
        
        [HttpGet("{category}/{subCategory}")]
        public IList<ProductViewModel> GetProducts(string category, string subCategory)
        {
            return _productService.GetInfoAboutProducts(category, subCategory);
        }

        [HttpGet("items")]
        public IList<ProductViewModel> GetAllProducts()
        {
            return _productService.GetAllProducts();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        //POST api/values
        [HttpPost]
        public IActionResult Create([FromBody]ProductViewModel productViewModel)
        {
            var product = _mapper.Map<ProductViewModel, Product>(productViewModel);
            _productService.CreateProduct(product);
            return Json(productViewModel);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
