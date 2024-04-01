using Es.Udc.DotNet.ModelUtil.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseDao
{
    public class PurchaseDaoEF : GenericDaoEntityFramework<Purchase, Int64>, IPurchaseDaoEF
    {

        public PurchaseDaoEF() { }

        Purchase purch = null;
        public List<Purchase> GetPurchases(long usuarioId)
        {
            DbSet<Purchase> purchase = Context.Set<Purchase>();

            List<Purchase> result = (from purch in purchase where purch.Card.userId == usuarioId select purch).ToList();

            return result;
        }

        public long GetMaxPurchaseId()
        {
            DbSet<Purchase> purchase = Context.Set<Purchase>();

            if (purchase.Any())
            {
                long result = purchase.Max(p => p.purchaseId);
                return result;
            }
                return 0;
        }

        public Purchase GetPurchaseByPK(long purchaseId, long productId)
        {
            DbSet<Purchase> purchase = Context.Set<Purchase>();

            var result = (from purch in purchase where purch.purchaseId == purchaseId && purch.productId == productId select purch);

            purch = result.FirstOrDefault();
            if (purch == null)
                throw new ModelUtil.Exceptions.InstanceNotFoundException(purch, "No existe el pedido {user}");

            return purch;

        }
    }
}
