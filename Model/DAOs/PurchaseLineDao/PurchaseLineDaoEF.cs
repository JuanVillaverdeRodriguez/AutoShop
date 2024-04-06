using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseLineDao
{
    public class PurchaseLineDaoEF : GenericDaoEntityFramework<PurchaseLine, Int64>, IPurchaseLineDaoEF
    {
        public PurchaseLineDaoEF() { }

        PurchaseLine purchLine = null;
        public PurchaseLine GetPurchaseLineByPK(long purchaseId, long productId)
        {
            DbSet<PurchaseLine> purchaseLine = Context.Set<PurchaseLine>();

            var result = (from purchLine in purchaseLine where purchLine.purchaseId == purchaseId && purchLine.productId == productId select purchLine);

            purchLine = result.FirstOrDefault();
            if (purchLine == null)
                throw new ModelUtil.Exceptions.InstanceNotFoundException(purchLine, "No existe el pedido {user}");

            return purchLine;

        }

        public List<PurchaseLine> GetPurchasesLines(long purchaseId)
        {
            DbSet<PurchaseLine> purchaseLine = Context.Set<PurchaseLine>();

            List<PurchaseLine> result = (from purchLine in purchaseLine where purchLine.purchaseId == purchaseId select purchLine).ToList();

            return result;

        }
    }
}
