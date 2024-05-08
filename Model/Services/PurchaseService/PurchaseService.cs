using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CardDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseLineDao;
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

        [Inject]
        public IPurchaseLineDaoEF PurchaseLineDao { get; set; }
 
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

        public Purchase Purchase(Card card, Cart.Cart cart, int direction, string purchaseDescription, bool urgent)
        {
            // Deberia comprobar que el usuario realmente tenga esa tarjeta

            try
            {
                CardDao.Find(card.card_number);
            }
            catch
            {
                throw new NoCardsException("No existe esta tarjeta.");
            }
            List<(long product, int count)> productList = cart.GetProductsTupleList();
            if (!productList.Any())
            {
                throw new EmptyCartException();
            }

            DateTime currentDate = DateTime.Now;

            Purchase newPurchase = new Purchase();
            newPurchase.card_number = card.card_number;
            newPurchase.targetPostalCode = direction;
            newPurchase.date = currentDate;
            newPurchase.descriptiveName = purchaseDescription;
            newPurchase.urgent = urgent;

            //PurchaseDao.Create(newPurchase);
            //Esto no furrula
            //Solucion tota para coger ID: Buscar el id mas alto guardado en la bd justo despues del Create
            long purchaseId = PurchaseDao.CreateAndReturn(newPurchase);
            newPurchase.purchaseId = purchaseId;

            foreach ((long productId, int count) in productList)
            {
                Product product = ProductDao.Find(productId);

                PurchaseLine newPurchaseLine = new PurchaseLine();

                newPurchaseLine.prize = product.prize;
                newPurchaseLine.quantity = count;
                newPurchaseLine.purchaseId = purchaseId;
                newPurchaseLine.productId = product.productId;

                PurchaseLineDao.Create(newPurchaseLine);

                product.stock -= count;

                

                ProductDao.Update(product);
            }
            return newPurchase;
        }

        public List<PurchaseInfoResult> GetPurchases(long usuarioId)
        {

            List<Purchase> purchasesList = PurchaseDao.GetPurchases(usuarioId);
            List<PurchaseInfoResult> purchasesInfoResultList = new List<PurchaseInfoResult>();
            foreach (Purchase purchase in purchasesList)
            {
                PurchaseInfoResult purchaseInfoResult = new PurchaseInfoResult(purchase.card_number, purchase.descriptiveName, purchase.date);
                purchasesInfoResultList.Add(purchaseInfoResult);

            }
            return purchasesInfoResultList;

        }

        //TODO: Hacer DTO: PurchaseLinesInfoResult
        public List<PurchaseLine> GetPurchasesLines(long purchaseId)
        {
            return PurchaseLineDao.GetPurchasesLines(purchaseId);
        }
    }
}
