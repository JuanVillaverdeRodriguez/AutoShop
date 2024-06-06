using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService
{
    public class ProductResult
    {
        public String name { get; private set; }
        public String category { get; private set; }
        public double price { get; private set; }
        public DateTime addedDate { get; private set; }
        public String cartUrl { get; private set; }
        public String detailsUrl { get; private set; }
        public int stock { get; private set; }
        public ProductResult(String name, String category, double price, DateTime addedDate, String cartUrl, String detailsUrl, int stock)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.addedDate = addedDate;
            this.cartUrl = cartUrl;
            this.detailsUrl = detailsUrl;
            this.stock = stock;
        }
    }
}
