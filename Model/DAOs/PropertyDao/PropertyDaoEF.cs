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

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.PropertyDao
{
    public class PropertyDaoEF : GenericDaoEntityFramework<Property, Int64>, IPropertyDaoEF
    {
        public PropertyDaoEF() { }

        Property prop = null;

        public List<Property> getProductDetails(long productId)
        {
            DbSet<Property> property = Context.Set<Property>();

            List<Property> result = (from prop in property where prop.productId == productId select prop).ToList();

            return result;
        }
    }
}
