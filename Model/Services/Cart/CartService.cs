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
    public class CartService : ICartService
    {
        [Inject]
        public IProductDaoEF ProductDao { get; set; }

        public CartService()
        {

        }

        //Añadir más unidades de un mismo producto actualemnte se modela como añadir otro producto más

        public void AddProductToCart(Product product, Cart cart)
        {
            cart.AddProduct(product);
        }

        public void RemoveProductFromCart(Product productId, Cart cart)
        {
            cart.RemoveProduct(productId);
        }

        //No tenemos claro que es lo mas conveniente que devuelva este metodo
        //Tupla (Producto, count)?
        public List<Product> GetProducts(Cart cart)
        {
            return cart.GetProducts();
        }

    }
}
