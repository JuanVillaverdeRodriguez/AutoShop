using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService
{
    public class ProductResult
    {
        private String name { get; set; }
        private String category { get; set; }
        private double price { get; set; }
        private DateTime addedDate { get; set; }
        private String cartUrl { get; set; }
        private String detailsUrl { get; set; }



        public ProductResult(String name, String category, double price, DateTime addedDate, String cartUrl, String detailsUrl)
        {
            this.name = name;
            this.category = category;
            this.price = price;
            this.addedDate = addedDate;
            this.cartUrl = cartUrl;
            this.detailsUrl = detailsUrl;

        }
    }
}
