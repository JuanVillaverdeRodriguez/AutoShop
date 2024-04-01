using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CardDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService
{
    public class PurchaseService : IPurchaseService
    {
        [Inject]
        public ICardDaoEF CardDao { get; set; }

        [Inject]
        public IProductDaoEF ProductDao { get; set; }

        [Inject]
        public IPurchaseDaoEF PurchaseDao { get; set; }
        public CardInfoResult GetCardInfo(Card card)
        {
            CardInfoResult cardInfoResult = new CardInfoResult(card.card_number, card.type, card.csv, card.expiration_date, card.defaultCard);
            return cardInfoResult;
        }

        public CardInfoResult GetDefaultCardInfo(long usuarioId)
        {

            List<Card> cardsList = CardDao.findCardsByUsuarioId(usuarioId);
            if (!cardsList.Any())
            {
                throw new NoCardsException();
            }
            foreach (Card card in cardsList)
            {
                if (card.defaultCard == true)
                {
                    CardInfoResult cardInfoResult = new CardInfoResult(card.card_number, card.type, card.csv, card.expiration_date, card.defaultCard);
                    return cardInfoResult;
                }
            }
            throw new NoDefaultCardException();

        }

        public List<Purchase> Purchase(Card card, Cart.Cart cart, int direction, string purchaseDescription)
        {
            List<(Product product, int count)> productList = GetProductsTupleList(cart);
            if (!productList.Any())
            {
                throw new EmptyCartException();
            }

            DateTime currentDate = DateTime.Now;
            long newPurchaseId = PurchaseDao.GetMaxPurchaseId()+1;

            List<Purchase> purchasesList = new List<Purchase>();
            foreach ((Product product, int count) in productList)
            {
                double purchasePrize = (product.prize * count);

                Purchase newPurchase = new Purchase();
                newPurchase.card_number = card.card_number;
                newPurchase.targetPostalCode = direction;
                newPurchase.prize = purchasePrize;
                newPurchase.quantity = count;
                newPurchase.date = currentDate;
                newPurchase.purchaseId = newPurchaseId;
                newPurchase.descriptiveName = purchaseDescription;
                purchasesList.Add(newPurchase);
            }
            return purchasesList;
        }

        public List<PurchaseInfoResult> GetPurchases(long usuarioId)
        {

            List<Purchase> purchasesList = PurchaseDao.GetPurchases(usuarioId);
            List<PurchaseInfoResult> purchasesInfoResultList = new List<PurchaseInfoResult>();
            foreach (Purchase purchase in purchasesList)
            {
                PurchaseInfoResult purchaseInfoResult = new PurchaseInfoResult(purchase.card_number, purchase.descriptiveName, purchase.prize, purchase.date);
                purchasesInfoResultList.Add(purchaseInfoResult);

            }
            return purchasesInfoResultList;

        }
        public void AddProductToCart(Product product, Cart.Cart cart)
        {
            cart.AddProduct(product);
        }

        public void RemoveProductFromCart(Product productId, Cart.Cart cart)
        {
            cart.RemoveProduct(productId);
        }

        //No tenemos claro que es lo mas conveniente que devuelva este metodo
        //Tupla (Producto, count)?
        public List<Product> GetProductsList(Cart.Cart cart)
        {
            return cart.GetProductsList();
        }

        public List<(Product product, int count)> GetProductsTupleList(Cart.Cart cart)
        {
            return cart.GetProductsTupleList();
        }
    }
}
