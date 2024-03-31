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

namespace Es.Udc.DotNet.PracticaMaD.Test
{
    /// <summary>
    /// This is a test class for IUserServiceTest and is intended to contain all IUserServiceTest
    /// Unit Tests
    /// </summary>
    [TestClass]
    public class IUserServiceTest
    {
        
        // Variables used in several tests are initialized here
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

        //IGUAL HAY QUE CREAR UNA WORKSHOP PRIMERO EN LA TABLA PARA QUE FUNCIONE ALGUNO DE LOS TESTS

        /// <summary>
        /// Gets or sets the test context which provides information about and functionality for the
        /// current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        /// <summary>
        /// test del correcto funcionamiento del RegisterUsuario
        /// </summary>
        [TestMethod]
        public void RegisterUserTest()
        {
            using (var scope = new TransactionScope())
            {
                // Register user and find profile
                var userId = UsuarioService.RegisterUsuario(alias, password, new UserProfileDetails(name, surname, email, language, workshopId));

                var user = UsuarioDao.Find(userId);

                // Check data
                Assert.AreEqual(userId, user.userId);
                Assert.AreEqual(alias, user.alias);
                Assert.AreEqual(password, user.password);
                Assert.AreEqual(name, user.user_name);
                Assert.AreEqual(surname, user.user_surname);
                Assert.AreEqual(email, user.email);
                Assert.AreEqual(language, user.language);
                Assert.AreEqual(workshopId, user.workshopId);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        /// testeamos intentar registrar un usuario ya existente
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DuplicateInstanceException))]
        public void RegisterDuplicatedUserTest()
        {
            using (var scope = new TransactionScope())
            {
                // Registramos un usuario
                UsuarioService.RegisterUsuario(alias, password, new UserProfileDetails(name, surname, email, language, workshopId));

                // Lo registramos de nuevo
                UsuarioService.RegisterUsuario(alias, password, new UserProfileDetails(name, surname, email, language, workshopId));

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        ///// <summary>
        /////A test for Login with clear password
        /////</summary>
        [TestMethod]
        public void SignInTest()
        {
            using (var scope = new TransactionScope())
            {
                var userId = UsuarioService.RegisterUsuario(alias, password, new UserProfileDetails(name, surname, email, language, workshopId));

                var expected = new UserProfileDetails(name, surname, email, language, workshopId);

                var actual = UsuarioService.SignIn(alias, password);

                Assert.AreEqual(expected, actual);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        ///// <summary>
        /////A test for Login with incorrect password
        /////</summary>
        [TestMethod]
        [ExpectedException(typeof(MistakenCredentialsException))]
        public void SigInMistakenCredentialsTest()
        {
            using (var scope = new TransactionScope())
            {
                // Register user
                var userId = UsuarioService.RegisterUsuario(alias, password, new UserProfileDetails(name, surname, email, language, workshopId));

                // Login with incorrect (clear) password
                var actual = UsuarioService.SignIn(alias, password + "wrong");

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        /// A test for FindUserProfileDetails
        /// </summary>
        [TestMethod]
        public void FindUsuarioDetailsTest()
        {
            using (var scope = new TransactionScope())
            {
                var expected = new UserProfileDetails(name, surname, email, language, workshopId);

                var userId = UsuarioService.RegisterUsuario(alias, password, expected);

                var obtained = UsuarioService.FindUsuarioDetails(userId);

                Assert.AreEqual(expected, obtained);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        /// A test for FindUserProfileDetails when the user does not exist
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void FindUserProfileDetailsForNonExistingUserTest()
        {
            UsuarioService.FindUsuarioDetails(NON_EXISTENT_USER_ID);
        }

        /// <summary>
        /// A test for UpdateUserProfileDetails
        /// </summary>
        [TestMethod]
        public void UpdateUserProfileDetailsTest()
        {
            using (var scope = new TransactionScope())
            {
                // Register user and update profile details
                var userId = UsuarioService.RegisterUsuario(alias, password, new UserProfileDetails(name, surname, email, language, workshopId));

                var expected = new UserProfileDetails(name + "updated", surname + "updated", email + "updated", "fr", 1);

                UsuarioService.UpdateUsuarioDetails(userId, expected);

                var obtained = UsuarioService.FindUsuarioDetails(userId);

                Assert.AreEqual(expected, obtained);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        /// A test for UpdateUserProfileDetails when the user does not exist
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void UpdateUserProfileDetailsForNonExistingUserTest()
        {
            using (var scope = new TransactionScope())
            {
                UsuarioService.UpdateUsuarioDetails(NON_EXISTENT_USER_ID, new UserProfileDetails(name, surname, email, language, workshopId));

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        /// test del correcto funcionamiento del RegisterUsuario
        /// </summary>
        [TestMethod]
        public void RegisterWorkshopTest()
        {
            using (var scope = new TransactionScope())
            {
                // Register user and find profile
                var wshopId = UsuarioService.RegisterWorkshop(postalcode, country, workshopname);

                var wshop = WorkshopDao.Find(workshopId);

                // Check data
                Assert.AreEqual(wshopId, wshop.workshopId);
                Assert.AreEqual(postalcode, wshop.postal_code);
                Assert.AreEqual(country, wshop.Country);
                Assert.AreEqual(workshopname, wshop.workshop_name);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        /// <summary>
        /// testeamos intentar registrar un usuario ya existente
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DuplicateInstanceException))]
        public void RegisterDuplicatedWorkshopTest()
        {
            using (var scope = new TransactionScope())
            {
                // Registramos un usuario
                UsuarioService.RegisterWorkshop(postalcode, country, workshopname);

                // Lo registramos de nuevo
                UsuarioService.RegisterWorkshop(postalcode, country, workshopname);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod]
        public void TestCreateCard()
        {
            using (var scope = new TransactionScope())
            {
                // Register user and find profile
                UsuarioService.CreateCard(cardnumber, usrId, type, csv, expirationdate);

                var card = CardDao.Find(cardnumber);

                // Check data
                Assert.AreEqual(cardnumber, card.card_number);
                Assert.AreEqual(usrId, card.userId);
                Assert.AreEqual(type, card.type);
                Assert.AreEqual(csv, card.csv);
                Assert.AreEqual(expirationdate, card.expiration_date);


                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateInstanceException))]
        public void CreateDuplicatedCardTest()
        {
            using (var scope = new TransactionScope())
            {
                // Creamos una tarjeta
                UsuarioService.CreateCard(cardnumber, usrId, type, csv, expirationdate);

                // La volvemos a crear
                UsuarioService.CreateCard(cardnumber, usrId, type, csv, expirationdate);

                // transaction.Complete() is not called, so Rollback is executed.
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void DeleteCardTest()
        {
            using (var scope = new TransactionScope())
            {
                //Creamos una tarjeta
                UsuarioService.CreateCard(cardnumber, usrId, type, csv, expirationdate);

                //La borramos
                UsuarioService.DeleteCard(cardnumber, usrId);

                //la buscamos en la BD (devuelve InstanceNotFound)
                CardDao.Find(cardnumber);
            }
        }


        #region Additional test attributes

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();

            UsuarioDao = kernel.Get<IUsuarioDaoEF>();
            WorkshopDao = kernel.Get<IWorkshopDaoEF>();
            CardDao = kernel.Get<ICardDaoEF>();
            UsuarioService = kernel.Get<IUsuarioService>();
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
