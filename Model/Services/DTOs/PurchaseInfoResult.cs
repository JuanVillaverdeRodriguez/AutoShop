using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService
{
    public class PurchaseInfoResult
    {
        public long cardNumber { get; private set; }
        public string descriptiveName { get; private set; }
        public DateTime purchaseDate { get; private set; }

        public PurchaseInfoResult(long cardNumber, string descriptiveName, DateTime purchaseDate)
        {
            this.cardNumber = cardNumber;
            this.descriptiveName = descriptiveName;
            this.purchaseDate = purchaseDate;
        }
    }
}
