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
using Es.Udc.DotNet.PracticaMaD.Model.Services.Cart;
using System.Collections.Generic;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseLineDao;

namespace Es.Udc.DotNet.PracticaMaD.Test.ServiceTest
{
    [TestClass]
    public class IPurchaseServiceTest
    {
        //Const variable definition...
        const long usuarioId1 = 1;
        const long usuarioId2 = 2;
        const long usuarioId3 = 3;

        const long cardId1 = 2349234234;
        const long cardId10 = 10;


        const long productId1 = 1;
        const long productId2 = 2;

        private static IKernel kernel;
        private static IPurchaseService PurchaseService;
        private static IPurchaseDaoEF PurchaseDao;
        private static ICardDaoEF CardDao;
        private static IProductDaoEF ProductDao;
        private static IPurchaseLineDaoEF PurchaseLineDao;

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
        [ExpectedException(typeof(NoCardsException))]
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

        [TestMethod]
        public void PurchaseTest()
        {
            using (var scope = new TransactionScope())
            {
                Card card = CardDao.Find(cardId1);
                Cart cart = new Cart();
                Product product1 = ProductDao.Find(productId1);

                cart.AddProduct(product1.productId);

                Purchase pedido = PurchaseService.Purchase(card, cart, 36121, "Estoy comprando unicamente para probar", true);
                Assert.AreEqual(card.card_number, pedido.card_number);
                Assert.AreEqual(36121, pedido.targetPostalCode);
                Assert.AreEqual("Estoy comprando unicamente para probar", pedido.descriptiveName);

                List<PurchaseLine> purchaseLinesList = PurchaseLineDao.GetPurchasesLines(1);

                foreach (PurchaseLine purchaseLine in purchaseLinesList)
                {
                    Assert.AreEqual(1, purchaseLine.purchaseId);
                    Assert.AreEqual(product1.productId, purchaseLine.productId);
                    Assert.AreEqual(1, purchaseLine.quantity);
                    Assert.AreEqual(product1.prize, purchaseLine.prize);
                }

            }

        }

        [TestMethod]
        [ExpectedException(typeof(EmptyCartException))]
        public void PurchaseEmptyCartExceptionTest()
        {
            using (var scope = new TransactionScope())
            {
                Card card = CardDao.Find(cardId1);
                Cart cart = new Cart();

                PurchaseService.Purchase(card, cart, 36121, "Estoy comprando unicamente para probar", true);
            }

        }
        [TestMethod]
        [ExpectedException(typeof(NoCardsException))]
        public void PurchasNoCardsExceptionTest()
        {
            using (var scope = new TransactionScope())
            {
                Card card = new Card();
                Cart cart = new Cart();
                Product product1 = ProductDao.Find(productId1);
                Product product2 = ProductDao.Find(productId2);

                cart.AddProduct(product1.productId);
                cart.AddProduct(product2.productId);

                PurchaseService.Purchase(card, cart, 36121, "Estoy comprando unicamente para probar", true);
            }

        }

        [TestMethod]
        public void GetPurchasesTest()
        {
            using (var scope = new TransactionScope())
            {
                PurchaseService.GetPurchases(usuarioId1);

            }
        }

        #region Additional test attributes
        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();

            PurchaseService = kernel.Get<IPurchaseService>();
            PurchaseDao = kernel.Get<IPurchaseDaoEF>();
            CardDao = kernel.Get<ICardDaoEF>();
            ProductDao = kernel.Get<IProductDaoEF>();
        }

        //Use ClassCleanup to run code after all tests in a class have run  
        [ClassCleanup]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize]
        public void MyTestInitialize()
        {
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup]
        public void MyTestCleanup()
        {
        }

        #endregion Additional test attributes


    }
}
