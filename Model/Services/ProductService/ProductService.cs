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

        public List<ProductResult> findProduct(string productName)
        {
            List<Product> productList = ProductDao.findProductsByName(productName);

            List<ProductResult> productResultList = new List<ProductResult>();

            foreach (Product product in productList)
            {
                Category category = CategoryDao.findCategoryById(product.categoryId);

                //Falta manejar la excepcion del details
                String detailsUrl = ProductDao.getDetailedProductUrl(product.productId);

                ProductResult productResult = new ProductResult(productName, category.categoryName, product.prize, product.date, "urlCart", detailsUrl);

                productResultList.Append(productResult);

            }

            return productResultList;

        }

        public List<ProductResult> findProduct(string productName, string selectedCategory)
        {
            List<Product> productList = ProductDao.findProductsByName(productName);

            List<ProductResult> productResultList = new List<ProductResult>();

            foreach (Product product in productList)
            {
                Category category = CategoryDao.findCategoryById(product.categoryId);
                if (category.Equals(selectedCategory))
                {
                    //Falta manejar la excepcion del details
                    String detailsUrl = ProductDao.getDetailedProductUrl(product.productId);
                    ProductResult productResult = new ProductResult(productName, category.categoryName, product.prize, product.date, "urlCart", detailsUrl);

                    productResultList.Append(productResult);
                }
            }

            return productResultList;

        }
    }
}
