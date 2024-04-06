using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService
{
    public class ProductDetailsResult
    {
        public String propertyName { get; private set; }
        public String propertyValue { get; private set; }


        public ProductDetailsResult(String propertyName, String propertyValue)
        {
            this.propertyName = propertyName;
            this.propertyValue = propertyValue;
        }

        public override bool Equals(object obj)
        {

            ProductDetailsResult target = (ProductDetailsResult)obj;

            return (this.propertyName == target.propertyName)
                  && (this.propertyValue == target.propertyValue);
        }

        public override int GetHashCode()
        {
            return this.propertyName.GetHashCode();
        }
    }
}
