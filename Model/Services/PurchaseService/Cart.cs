using Es.Udc.DotNet.PracticaMaD.Model.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.Cart
{
    /*public class Cart
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
    }*/

    public class Cart
    {
        private List<CartProduct> cartProducts;
        public Cart()
        {
            cartProducts = new List<CartProduct>();
        }
        public void AddProduct(CartProduct cartProduct)
        {
            int index = cartProducts.IndexOf(cartProduct);

            // Si el producto no existe aun en el carrito, añadelo
            if (index == -1)
            {
                cartProducts.Add(cartProduct);
            }
            else // Si el producto ya existe, añade uno más
            {
                cartProducts[index].Quantity += 1;
            }
        }

        // Elimina un producto del carrito (Todas las unidades)
        public void RemoveProduct(CartProduct cartProduct)
        {
            cartProducts.RemoveAll(p => p.Equals(cartProduct));
        }

        // Elimina una unidad del producto del carrito
        // Si es la ultima, se elimina por completo
        public void SubstractProduct(CartProduct cartProduct)
        {
            int index = cartProducts.IndexOf(cartProduct);

            cartProducts[index].Quantity -= 1;

            if (cartProducts[index].Quantity <= 0)
            {
                cartProducts.RemoveAll(p => p.Equals(cartProduct));
            }
        }
        public int GetQuantity(CartProduct cartProduct)
        {
            CartProduct cartProductSearched = cartProducts.Find(p => p.Equals(cartProduct));

            if (cartProductSearched != null)
                return cartProductSearched.Quantity;
            else
                return 0;
        }
        public List<CartProduct> GetCartProducts()
        {
            return cartProducts;
        }

        public void EmptyCart()
        {
            cartProducts = new List<CartProduct>();
        }

    }
}
