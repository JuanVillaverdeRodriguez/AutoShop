using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseLineDao
{
    public interface IPurchaseLineDaoEF : IGenericDao<PurchaseLine, Int64>
    {
        PurchaseLine GetPurchaseLineByPK(long purchaseId, long productId);

        List<PurchaseLine> GetPurchasesLines(long purchaseId);

    }
}
