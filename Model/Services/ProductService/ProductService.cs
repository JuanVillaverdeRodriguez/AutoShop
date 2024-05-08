using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PropertyDao;
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

        [Inject]
        public IPropertyDaoEF PropertyDao { get; set; }

        public List<ProductResult> findProduct(string productName)
        {
            List<Product> productList = ProductDao.findProductsByName(productName);

            List<ProductResult> productResultList = new List<ProductResult>();

            foreach (Product product in productList)
            {
                Category category = CategoryDao.findCategoryById(product.categoryId);

                string detailsUrl = "" + product.productId;

                ProductResult productResult = new ProductResult(product.name, category.categoryName, product.prize, product.date, "urlCart", detailsUrl);

                productResultList.Add(productResult);
                

            }

            return productResultList;

        }

        public ProductResult findProductById(long productId)
        {
            ProductResult productResult = null;

            try
            {
                Product product = ProductDao.Find(productId);

                string detailsUrl = "" + product.productId;
                Category category = CategoryDao.findCategoryById(product.categoryId);


                productResult = new ProductResult(product.name, category.categoryName, product.prize, product.date, "urlCart", detailsUrl);

            }
            catch (Exception)
            {

            }

            return productResult;
        }

        public List<ProductResult> findProduct(string productName, string selectedCategory)
        {
            List<Product> productList = ProductDao.findProductsByName(productName);

            List<ProductResult> productResultList = new List<ProductResult>();

            foreach (Product product in productList)
            {
                Category category = CategoryDao.findCategoryById(product.categoryId);

                String fatherCatName = CategoryDao.findFatherCategoryByCategoryName(category.categoryName);
                
                if (category.categoryName.Equals(selectedCategory) || selectedCategory.Equals(fatherCatName))
                {
                    string detailsUrl = "" + product.productId;

                    ProductResult productResult = new ProductResult(product.name, category.categoryName, product.prize, product.date, "urlCart", detailsUrl);

                    productResultList.Add(productResult);
                }
            }

            return productResultList;

        }

        public List<ProductDetailsResult> getProductDetails(long productId)
        {
            List<ProductDetailsResult> productDetailsResultList = new List<ProductDetailsResult>();

            List<Property> productDetails = PropertyDao.getProductDetails(productId);

            foreach (Property property in productDetails)
            {
                ProductDetailsResult productDetailsResult = new ProductDetailsResult(property.property_name, property.property_value);
                productDetailsResultList.Add(productDetailsResult);
            }

            return productDetailsResultList;

        }
    }
}
