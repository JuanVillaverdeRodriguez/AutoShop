using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.ProductDao;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.Cart
{
    public interface ICartService
    {
        [Inject]
        IProductDaoEF ProductDao { get; set; }

        void AddProductToCart(Product product, Cart cart);
        void RemoveProductFromCart(Product product, Cart cart);
        List<Product> GetProducts(Cart cart);


    }
}
