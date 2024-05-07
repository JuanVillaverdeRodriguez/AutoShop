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
        private DbContext dbCommonContext;


        public PurchaseDaoEF() { }

        Purchase purch = null;
        public List<Purchase> GetPurchases(long usuarioId)
        {
            DbSet<Purchase> purchase = Context.Set<Purchase>();

            List<Purchase> result = (from purch in purchase where purch.Card.userId == usuarioId select purch).ToList();

            return result;
        }
        public long CreateAndReturn(Purchase purchase)
        {
            this.Create(purchase);

            DbSet<Purchase> purchase2 = Context.Set<Purchase>();
            if (purchase2.Any())
            {
                long result = purchase2.Max(p => p.purchaseId);
                return result;
            }
            return 0;



        }
    }
}

