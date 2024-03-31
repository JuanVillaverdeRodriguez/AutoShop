using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.ProductDao;
using Ninject;


namespace Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService
{
    public interface IPurchaseService
    {
        [Inject]
        IProductDaoEF ProductDao { get; set; }

        CardInfo GetDefaultCardInfo();

        CardInfo GetCardInfo(Card card);

        void Purchase(Card card, string direction, string purchaseDescription);

    }
}
