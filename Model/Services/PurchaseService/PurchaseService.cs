using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CardDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseLineDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.DTOs;
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

            List<CartProduct> cartProductList = cart.GetCartProducts();

            if (!cartProductList.Any())
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
            //Solucion tonta para coger ID: Buscar el id mas alto guardado en la bd justo despues del Create
            long purchaseId = PurchaseDao.CreateAndReturn(newPurchase);
            newPurchase.purchaseId = purchaseId;

            foreach (CartProduct cartProduct in cartProductList)
            {
                PurchaseLine newPurchaseLine = new PurchaseLine();

                newPurchaseLine.purchaseId = purchaseId;
                newPurchaseLine.productId = cartProduct.ProductId;
                newPurchaseLine.prize = cartProduct.Price;
                newPurchaseLine.quantity = cartProduct.Quantity;

                PurchaseLineDao.Create(newPurchaseLine);

                Product product = ProductDao.Find(cartProduct.ProductId);
                product.stock -= cartProduct.Quantity;

                if (product.stock < 0)
                {
                    product.stock = 0;
                    throw new OutOfStockException(product.name);
                }
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

        public Card FindCardByCardNumber(long cardnumber)
        {
            try
            {
                Card card = CardDao.Find(cardnumber);

                return card;
            }
            catch (Exception)
            {
                throw new ModelUtil.Exceptions.InstanceNotFoundException(cardnumber, "No existe una card asociada {cardnumber}");
            }
        }
    }
}
