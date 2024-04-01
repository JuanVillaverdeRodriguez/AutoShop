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
        //es probable que sobre
        public long categoryId { get; private set; }


        public ProductDetailsResult(String propertyName, String propertyValue, long categoryId)
        {
            this.propertyName = propertyName;
            this.propertyValue = propertyValue;
            this.categoryId = categoryId;
        }

        public override bool Equals(object obj)
        {

            ProductDetailsResult target = (ProductDetailsResult)obj;

            return (this.propertyName == target.propertyName)
                  && (this.propertyValue == target.propertyValue)
                  && (this.categoryId == target.categoryId);
        }

        public override int GetHashCode()
        {
            return this.propertyName.GetHashCode();
        }
    }
}
