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

    [TestClass]
    public class IUserServiceTest
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
        // Estos ids ya existen en la BD de test creados mediante sentencias INSERT INTO,
        // esto es para facilitar los tests y no tener que crear un workshop cada vez que queramos registrar un usuario...
        private const long usrId = 1;
        private const long workshopId = 1;
        private static IKernel kernel;
        private static IUsuarioService UsuarioService;
        private static IUsuarioDaoEF UsuarioDao;
        private static ICardDaoEF CardDao;
        private static IWorkshopDaoEF WorkshopDao;

        private TransactionScope transaction;


        public TestContext TestContext { get; set; }

        // test del correcto funcionamiento del RegisterUsuario

        [TestMethod]
        public void RegisterUserTest()
        {
            using (var scope = new TransactionScope())
            {
                // Registramos el usuario
                var userId = UsuarioService.RegisterUsuario(alias, password, new UserProfileDetails(name, surname, email, language, country, workshopId));

                // Lo buscamos
                var user = UsuarioDao.Find(userId);

                // Comprobamos
                Assert.AreEqual(userId, user.userId);
                Assert.AreEqual(alias, user.alias);
                Assert.AreEqual(password, user.password);
                Assert.AreEqual(name, user.user_name);
                Assert.AreEqual(surname, user.user_surname);
                Assert.AreEqual(email, user.email);
                Assert.AreEqual(language, user.language);
                Assert.AreEqual(country, user.country);
                Assert.AreEqual(workshopId, user.workshopId);

                // transaction.Complete() no se llama, para que se ejecute el Rollback.
            }
        }

        // testeamos intentar registrar un usuario ya existente

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

                // transaction.Complete() no se llama, para que se ejecute el Rollback.
            }
        }

        // Testeamos loggear un usuario

        [TestMethod]
        public void SignInTest()
        {
            using (var scope = new TransactionScope())
            {
                var userId = UsuarioService.RegisterUsuario(alias, password, new UserProfileDetails(name, surname, email, language, country, workshopId));


                var expected = new SignInResult(userId, name, surname, email, language, country, workshopId);

                var actual = UsuarioService.SignIn(alias, password);

                Assert.AreEqual(expected, actual);

                // transaction.Complete() no se llama, para que se ejecute el Rollback.
            }
        }

        // Testeamos loggear con una constraseña errónea

        [TestMethod]
        [ExpectedException(typeof(MistakenCredentialsException))]
        public void SigInMistakenCredentialsTest()
        {
            using (var scope = new TransactionScope())
            {
                // Registramos usuario
                var userId = UsuarioService.RegisterUsuario(alias, password, new UserProfileDetails(name, surname, email, language, workshopId));

                // Loggeamos con contraseña incorrecta
                var actual = UsuarioService.SignIn(alias, password + "wrong");

                // transaction.Complete() no se llama, para que se ejecute el Rollback.
            }
        }


        // test del correcto funcionamiento de FindUsuarioDetails

        [TestMethod]
        public void FindUsuarioDetailsTest()
        {
            using (var scope = new TransactionScope())
            {
                var expected = new UserProfileDetails(name, surname, email, language, country, workshopId);

                var userId = UsuarioService.RegisterUsuario(alias, password, expected);

                var obtained = UsuarioService.FindUsuarioDetails(userId);

                Assert.AreEqual(expected, obtained);

                // transaction.Complete() no se llama, para que se ejecute el Rollback.
            }
        }

        // testea FindUsuarioDetails cuando el usuario no existe

        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void FindUserProfileDetailsForNonExistingUserTest()
        {
            UsuarioService.FindUsuarioDetails(NON_EXISTENT_USER_ID);
        }

        // test del correcto funcionamiento de UpdateUserProfileDetails

        [TestMethod]
        public void UpdateUsuarioDetailsTest()
        {
            using (var scope = new TransactionScope())
            {
                // Registramos el usuario
                var userId = UsuarioService.RegisterUsuario(alias, password, new UserProfileDetails(name, surname, email, language, country, workshopId));

                var expected = new UserProfileDetails(name + "updated", surname + "updated", email + "updated", "fr", "FR", workshopId);

                UsuarioService.UpdateUsuarioDetails(userId, expected);

                var obtained = UsuarioService.FindUsuarioDetails(userId);

                Assert.AreEqual(expected, obtained);

                // transaction.Complete() no se llama, para que se ejecute el Rollback.
            }
        }

        // test del UpdateUsuarioDetails cuando el usuario no existe

        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void UpdateUsuarioDetailsForNonExistingUserTest()
        {
            using (var scope = new TransactionScope())
            {
                UsuarioService.UpdateUsuarioDetails(NON_EXISTENT_USER_ID, new UserProfileDetails(name, surname, email, language, workshopId));

                // transaction.Complete() no se llama, para que se ejecute el Rollback.
            }
        }

        // test del correcto funcionamiento del RegisterWorkshop

        [TestMethod]
        public void RegisterWorkshopTest()
        {
            using (var scope = new TransactionScope())
            {
                // Registramos el taller
                var wshopId = UsuarioService.RegisterWorkshop(postalcode, workshopname);

                // Lo buscamos
                var wshop = WorkshopDao.Find(wshopId);

                // Comprobamos
                Assert.AreEqual(wshopId, wshop.workshopId);
                Assert.AreEqual(postalcode, wshop.postal_code);
                Assert.AreEqual(workshopname, wshop.workshop_name);

                // transaction.Complete() no se llama, para que se ejecute el Rollback.
            }
        }

        // testeamos intentar registrar un taller ya existente

        [TestMethod]
        [ExpectedException(typeof(DuplicateInstanceException))]
        public void RegisterDuplicatedWorkshopTest()
        {
            using (var scope = new TransactionScope())
            {
                // Registramos un taller
                UsuarioService.RegisterWorkshop(postalcode, workshopname);

                // Lo registramos de nuevo
                UsuarioService.RegisterWorkshop(postalcode, workshopname);

                // transaction.Complete() no se llama, para que se ejecute el Rollback.
            }
        }

        // test del correcto funcionamiento del CreateCard

        [TestMethod]
        public void TestCreateCard()
        {
            using (var scope = new TransactionScope())
            {
                // Creamos una tarjeta
                UsuarioService.CreateCard(555566667777, usrId, type, csv, expirationdate);

                // La buscamos
                var card = CardDao.Find(555566667777);

                // Comprobamos
                Assert.AreEqual(555566667777, card.card_number);
                Assert.AreEqual(usrId, card.userId);
                Assert.AreEqual(type, card.type);
                Assert.AreEqual(csv, card.csv);
                Assert.AreEqual(expirationdate, card.expiration_date);


                // transaction.Complete() no se llama, para que se ejecute el Rollback.
            }
        }

        // testeamos intentar registrar una tarjeta ya existente

        [TestMethod]
        [ExpectedException(typeof(DuplicateInstanceException))]
        public void CreateDuplicatedCardTest()
        {
            using (var scope = new TransactionScope())
            {
                // Creamos una tarjeta
                UsuarioService.CreateCard(222233334444, usrId, type, csv, expirationdate);

                // La volvemos a crear
                UsuarioService.CreateCard(222233334444, usrId, type, csv, expirationdate);

                // transaction.Complete() no se llama, para que se ejecute el Rollback.
            }
        }

        // testeamos borrar una tarjeta inexistente

        [TestMethod]
        [ExpectedException(typeof(InstanceNotFoundException))]
        public void DeleteCardTest()
        {
            using (var scope = new TransactionScope())
            {
                //Creamos una tarjeta
                UsuarioService.CreateCard(333344445555, usrId, type, csv, expirationdate);

                //La borramos
                UsuarioService.DeleteCard(333344445555, usrId);

                //la buscamos en la BD (devuelve InstanceNotFound)
                CardDao.Find(333344445555);
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
