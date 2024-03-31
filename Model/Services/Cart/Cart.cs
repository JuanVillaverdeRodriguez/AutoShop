using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.Cart
{
    public class Cart
    {
        private List<Product> productList;
        public Cart() {
            productList = new List<Product>();
        }
        public void AddProduct(Product product)
        {
            productList.Add(product);
        }
        public void RemoveProduct(Product product)
        {
            productList.RemoveAll(p => p.productId == product.productId);
        }

        public List<Product> GetProducts()
        {
            return productList;
        }
    }
}
