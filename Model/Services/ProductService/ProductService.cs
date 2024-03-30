using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.ProductDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService
{
    public class ProductService : IProductService
    {

        public ProductService() { }

        [Inject]
        public IProductDaoEF ProductDao { get; set; }

        [Inject]
        public ICategoryDaoEF CategoryDao { get; set; }

        public ProductResult findProduct(string productName)
        {
            Product product = ProductDao.findProductByName(productName);

            Category category = CategoryDao.findCategoryById(product.categoryId);

            ProductResult productResult = new ProductResult(productName, category.categoryName,  product.prize, product.date, "urlCart", "urlDetails");

            return productResult;

        }

        public ProductResult findProduct(string productName, string selectedCategory)
        {
            Product product = ProductDao.findProductByName(productName);

            Category category = CategoryDao.findCategoryById(product.categoryId);

            if (category.Equals(selectedCategory))
            {
                ProductResult productResult = new ProductResult(productName, category.categoryName, product.prize, product.date, "urlCart", "urlDetails");

                return productResult;
            }
            else
            {
                throw new ModelUtil.Exceptions.InstanceNotFoundException(product, "No existen productos para dicha categoria {product}");

            }

        }
    }
}
