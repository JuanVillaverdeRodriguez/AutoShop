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

        public List<Product> GetProductsList()
        {
            return productList;
        }

        public List<(Product product, int count)> GetProductsTupleList()
        {
            List<(Product product, int count)> groupedProducts = new List<(Product product, int count)>();
            foreach (Product product in productList)
            {
                long productId = product.productId;
                int count = productList.Count(p => p.productId == productId);

                // Verificar si ya se ha agregado esta productId a la lista
                bool alreadyAdded = groupedProducts.Any(t => t.product.productId == productId);

                // Si el productId aún no está en la lista, lo agregamos
                if (!alreadyAdded)
                {
                    groupedProducts.Add((product, count));
                }
            }

            return groupedProducts;
        }
    }
}
