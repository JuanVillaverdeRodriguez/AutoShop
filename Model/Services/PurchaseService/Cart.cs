using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.Cart
{
    public class Cart
    {
        private List<long> productIdList;
        public Cart() {
            productIdList = new List<long>();
        }
        public void AddProduct(long productId)
        {
            productIdList.Add(productId);
        }
        public void RemoveProduct(long productId)
        {
            productIdList.RemoveAll(p => p == productId);
        }

        public List<long> GetProductsList()
        {
            return productIdList;
        }

        public List<(long productId, int count)> GetProductsTupleList()
        {
            List<(long productId, int count)> groupedProducts = new List<(long productId, int count)>();

            foreach (long productId in productIdList)
            {
                int count = productIdList.Count(p => p == productId);

                // Verificar si ya se ha agregado esta productId a la lista
                bool alreadyAdded = groupedProducts.Any(t => t.productId == productId);

                // Si el productId aún no está en la lista, lo agregamos
                if (!alreadyAdded)
                {
                    groupedProducts.Add((productId, count));
                }
            }

            return groupedProducts;
        }
    }
}
