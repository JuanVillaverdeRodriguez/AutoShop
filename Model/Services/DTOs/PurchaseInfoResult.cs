using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService
{
    public class PurchaseInfoResult
    {
        private long cardNumber;
        private string descriptiveName;
        private DateTime purchaseDate;

        public PurchaseInfoResult(long cardNumber, string descriptiveName, DateTime purchaseDate)
        {
            this.cardNumber = cardNumber;
            this.descriptiveName = descriptiveName;
            this.purchaseDate = purchaseDate;
        }
    }
}
