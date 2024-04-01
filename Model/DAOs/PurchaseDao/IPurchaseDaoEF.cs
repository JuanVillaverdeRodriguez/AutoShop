using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseDao
{
    public interface IPurchaseDaoEF : IGenericDao<Purchase, Int64>
    {
        List<Purchase> GetPurchases(long usuarioId);

        long GetMaxPurchaseId();

    }
}
