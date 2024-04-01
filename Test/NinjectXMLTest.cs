using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.UsuarioDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.WorkshopDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CardDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService;
using Es.Udc.DotNet.PracticaMaD.Test;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using System;
using System.Transactions;

namespace Es.Udc.DotNet.PracticaMaD.Test
{
    [TestClass]
    public class NinjectTest
    {
        // Variables a utilizar en los tests siguientes
        private const string alias = "alias";
        private const string password = "password";
        private const string name = "name";
        private const string surname = "lastName";
        private const string email = "user@udc.es";
        private const string language = "es";
        private const string country = "ES";
        private const string workshopname = "workshopname";
        private const string type = "visa";
        private const int postalcode = 15005;
        private const int csv = 000;
        private DateTime expirationdate = DateTime.Now.AddDays(30);
        private const long cardnumber = 111122223333;
        private const long NON_EXISTENT_USER_ID = -1;
        private const long NON_EXISTENT_WORKSHOP_ID = -1;
        //Estos ids ya existen en la BD de test creados mediante sentencias INSERT INTO,
        //esto es para facilitar los tests y no tener que crear un workshop cada vez que queramos registrar un usuario...
        private const long usrId = 1;
        private const long workshopId = 1;
        private static IKernel kernel;
        private static IUsuarioService UsuarioService;
        private static IUsuarioDaoEF UsuarioDao;
        private static ICardDaoEF CardDao;
        private static IWorkshopDaoEF WorkshopDao;

        private TransactionScope transaction;

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {

        }

        //Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup()
        {
            TestManager.ClearNInjectKernel(kernel);
        }

        //Use TestInitialize to run code before running each test
        [TestInitialize()]
        public void MyTestInitialize()
        {
            transaction = new TransactionScope();
        }

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            transaction.Dispose();
        }

        #endregion Additional test attributes

        [TestMethod()]
        public void NinjectTestMethod()
        {
            //kernel = TestManager.ConfigureNInjectKernel("./Modules/ninjectConfiguration.xml");
            kernel = TestManager.ConfigureNInjectKernel();


            IUsuarioDaoEF dao = kernel.Get<IUsuarioDaoEF>();

            Assert.IsInstanceOfType(dao, typeof(IUsuarioDaoEF));

        }
    }
}