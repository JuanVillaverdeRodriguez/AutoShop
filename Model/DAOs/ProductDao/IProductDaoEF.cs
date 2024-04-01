using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.ProductDao
{
    public interface IProductDaoEF : IGenericDao<Product, Int64>
    {
        //Devuelve una lista de todos los productos cuyo nombre contenga el productName que recibe como parámetro
        //Devuelve una lista vacía si no hay ninguno
        List<Product> findProductsByName(String productName);


    }
}
