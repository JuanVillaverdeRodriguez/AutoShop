using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.DTOs
{
    public class CartProduct
    {
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        //public bool IsUrgent { get; set; }

        public int Stock { get; set; }

        public CartProduct(long ProductId, String ProductName, double Price, int Quantity, int Stock)
        {
            this.ProductId = ProductId;
            this.ProductName = ProductName;
            this.Price = Price;
            this.Quantity = Quantity;
            this.Stock = Stock;
        }

        public override bool Equals(object obj)
        {

            CartProduct target = (CartProduct)obj;

            return (this.ProductId == target.ProductId);
        }


        public override int GetHashCode()
        {
            return this.ProductId.GetHashCode();
        }
    }
}
