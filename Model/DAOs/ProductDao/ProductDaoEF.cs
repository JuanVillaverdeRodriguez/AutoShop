using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using System.Management.Instrumentation;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.Dao;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.ProductDao
{
    public class ProductDaoEF : GenericDaoEntityFramework<Product, Int64>, IProductDaoEF
    {
        public ProductDaoEF() { }

        Product prod = null;
        public Product findProductByName(string productName)
        {

            DbSet<Product> product = Context.Set<Product>();

            var result = from prod in product where prod.name == productName select prod;

            prod = result.FirstOrDefault();
            if (prod == null)
                throw new ModelUtil.Exceptions.InstanceNotFoundException(prod, "No existe el producto {prod}");

            return prod;

        }

    }
}
