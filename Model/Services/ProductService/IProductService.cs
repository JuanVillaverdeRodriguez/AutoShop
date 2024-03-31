using Es.Udc.DotNet.ModelUtil.Transactions;
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
    public interface IProductService
    {
        [Inject]
        IProductDaoEF ProductDao { get; set; }

        [Inject]
        ICategoryDaoEF CategoryDao { get; set; }

        [Inject]
        IPropertyDaoEF PropertyDao { get; set; }

        [Transactional]
        List<ProductResult> findProduct(string productName);

        [Transactional]
        List<ProductResult> findProduct(string productName, string category);

        [Transactional]
        List<ProductDetailsResult> getProductDetails(long productId);


        // En teoria todo esto no se pide
        /*[Transactional]
        bool CreateProduct(String productName);

        [Transactional]

        bool DeleteProduct();

        [Transactional]

        bool UpdateProduct();*/
    }
}
