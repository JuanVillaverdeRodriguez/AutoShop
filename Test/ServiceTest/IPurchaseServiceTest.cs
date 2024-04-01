using Es.Udc.DotNet.PracticaMaD.Model.DAOs.UsuarioDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.WorkshopDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.ProductDao;

namespace Es.Udc.DotNet.PracticaMaD.Test.ServiceTest
{
    [TestClass]
    public class IPurchaseServiceTest
    {
        //Const variable definition...
        const long usuarioId1 = 1;
        const long usuarioId2 = 2;
        const long usuarioId3 = 3;

        const long cardId1 = 1;



        private static IKernel kernel;
        private static IPurchaseService PurchaseService;
        private static IPurchaseDaoEF PurchaseDao;
        private static ICardDaoEF CardDao;
        private static IProductDaoEF ProductDao;
        private TransactionScope transaction;

        public TestContext TestContext { get; set; }

        /// <summary>
        /// Comprueba si se obtiene la excepcion esperada (NoDefaultCardException) para GetDefaultCardInfo
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NoDefaultCardException))]
        public void GetDefaultCardInfoNoDefaultCardExceptionTest()
        {
            using (var scope = new TransactionScope())
            {
                PurchaseService.GetDefaultCardInfo(usuarioId1);

                // transaction.Complete() is not called, so Rollback is executed.
            }

        }

        [TestMethod]
        public void GetDefaultCardInfoNoCardsExceptionTest()
        {
            using (var scope = new TransactionScope())
            {
                PurchaseService.GetDefaultCardInfo(usuarioId2);

                // transaction.Complete() is not called, so Rollback is executed.
            }

        }

        [TestMethod]
        public void GetDefaultCardInfoTest()
        {
            using (var scope = new TransactionScope())
            {
                PurchaseService.GetDefaultCardInfo(usuarioId3);

                // transaction.Complete() is not called, so Rollback is executed.
            }

        }

        public void GetCardInfo()
        {
            using (var scope = new TransactionScope())
            {
                PurchaseService.GetCardInfo(cardId1);

            }

        }

        /*[TestMethod]

        CardInfoResult GetCardInfo(Card card);

        List<Purchase> Purchase(Card card, Cart.Cart cart, int direction, string purchaseDescription);
        List<PurchaseInfoResult> GetPurchases(long usuarioId);

        void AddProductToCart(Product product, Cart.Cart cart);
        void RemoveProductFromCart(Product product, Cart.Cart cart);
        List<Product> GetProductsList(Cart.Cart cart);

        List<(Product product, int count)> GetProductsTupleList(Cart.Cart cart);*/

    }
}
