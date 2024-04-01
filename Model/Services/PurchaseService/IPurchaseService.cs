using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CardDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseDao;
using Ninject;


namespace Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService
{
    public interface IPurchaseService
    {
        [Inject]
        ICardDaoEF CardDao { get; set; }

        [Inject]
        IProductDaoEF ProductDao { get; set; }

        [Inject]
        IPurchaseDaoEF PurchaseDao { get; set; }
        CardInfoResult GetDefaultCardInfo(long usuarioId);

        CardInfoResult GetCardInfo(Card card);

        List<Purchase> Purchase(Card card, Cart.Cart cart, int direction, string purchaseDescription);
        List<PurchaseInfoResult> GetPurchases(long usuarioId);

        void AddProductToCart(Product product, Cart.Cart cart);
        void RemoveProductFromCart(Product product, Cart.Cart cart);
        List<Product> GetProductsList(Cart.Cart cart);

        List<(Product product, int count)> GetProductsTupleList(Cart.Cart cart);

    }
}
