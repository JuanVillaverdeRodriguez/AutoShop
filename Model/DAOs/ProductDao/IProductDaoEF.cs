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
        List<Product> findProductsByName(String productName);

        String getDetailedProductUrl(long productId);

    }
}
