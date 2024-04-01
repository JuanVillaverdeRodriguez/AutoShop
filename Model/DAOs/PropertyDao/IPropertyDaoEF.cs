using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.PropertyDao
{
    public interface IPropertyDaoEF : IGenericDao<Property, Int64>
    {
        //Devuelve una lista con las propiedades de un producto dado
        //Devuelve una lista vacía en caso de que no tuviera
        List<Property> getProductDetails(long productId);
    }
}
