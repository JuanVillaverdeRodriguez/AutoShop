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

        public List<Purchase> GetPurchases(long usuarioId)
        {
            DbSet<Purchase> purchase = Context.Set<Purchase>();

            List<Purchase> result = (from purch in purchase where purch.Card.userId == usuarioId select purch).ToList();

            return result;
        }

        public long GetMaxPurchaseId()
        {
            DbSet<Purchase> purchase = Context.Set<Purchase>();

            var result = purchase.Max(p => p.purchaseId);

            return result;
        }
    }
}
