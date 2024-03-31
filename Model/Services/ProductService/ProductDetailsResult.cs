using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService
{
    public class ProductDetailsResult
    {
        private String propertyName { get; set; }
        private String propertyValue { get; set; }
        private long categoryId { get; set; }


        public ProductDetailsResult(String propertyName, String propertyValue, long categoryId)
        {
            this.propertyName = propertyName;
            this.propertyValue = propertyValue;
            this.categoryId = categoryId;
        }
    }
}
