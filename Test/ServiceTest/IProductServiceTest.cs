using Es.Udc.DotNet.PracticaMaD.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PropertyDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Exceptions;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using Ninject;
using System;
using System.Transactions;
using Es.Udc.DotNet.PracticaMaD.Model;

namespace Es.Udc.DotNet.PracticaMaD.Test
{

    [TestClass]
    public class IProductServiceTest
    {

        // Variables a utilizar en los tests siguientes
        //Este test hace uso de las Base de datos ya creada con varias filas de datos en ella
        /* Informacion relevante para entender el método de testeo de las clases es:
         hay creadas 2 categorías, neumáticos (id = 1) y neumáticos de invierno (id = 2)
         hay creados 3 productos (pirelli y firetruck como neumaticos de invierno, y michelin como neumáticos sin subcategoría)*/
        private const string productname1 = "Pirelli 289";
        private const string productname2 = "Firetruck 881";
        private const string productname3 = "michelin gcv12";
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
        private const long productId = 1;
        private static IKernel kernel;
        private static IProductService ProductService;
        private static IProductDaoEF ProductDao;
        private static IPropertyDaoEF PropertyDao;
        private static ICategoryDaoEF CategoryDao;

        private TransactionScope transaction;


        public TestContext TestContext { get; set; }

        // test del correcto funcionamiento del findProduct sin forzar categoría

        [TestMethod]
        public void findProduct1Test()
        {
            using (var scope = new TransactionScope())
            {
                // Busca los productos con nombre "Pirelli 289"
                List<ProductResult> product1 = ProductService.findProduct(productname1);

                // Busca los productos con nombre "Firetruck 881"
                List<ProductResult> product2 = ProductService.findProduct(productname2);

                // Busca los productos con nombre "michelin gcv12"
                List<ProductResult> product3 = ProductService.findProduct(productname3);

                // Comprobamos
                Assert.AreEqual(productname1, product1.First().name);
                Assert.AreEqual(productname2, product2.First().name);
                Assert.AreEqual(productname3, product3.First().name);

                // transaction.Complete() no se llama, para que se ejecute el Rollback.
            }
        }

        // test del correcto funcionamiento del findProduct forzando categoría

        [TestMethod]
        public void findProduct2Test()
        {
            using (var scope = new TransactionScope())
            {
                // Busca los productos con nombre "Pirelli 289" y pertencientes a la categoría con nombre "Neumaticos de invierno"
                var product1 = ProductService.findProduct(productname1, "Neumaticos de invierno");

                // Busca los productos con nombre "Firetruck 881" y pertencientes a la categoría con nombre "Neumaticos"
                // (Pero la categoryId en la tabla de productos de la BD para el producto con nombre "Firetruck 881" es 2 (Neumaticos de invierno) y Neumaticos tiene id 1)
                // así, tendría que encontrarlo al ser id 2 una subcategoría de id 1
                var product2 = ProductService.findProduct(productname2, "Neumaticos");
                // Comprobamos
                Assert.AreEqual(productname1, product1.FirstOrDefault().name);
                Assert.AreEqual(productname2, product2.FirstOrDefault().name);

                // transaction.Complete() no se llama, para que se ejecute el Rollback.
            }
        }

        // Testeamos recuperar los detalles de un producto

        [TestMethod]
        public void getProductDetailsTest()
        {
            using (var scope = new TransactionScope())
            {
                //recuperamoms las propiedades de el producto 1 "Pirelli 289"
                /* Estás deberían ser: 
                 diametro = 25 cm
                 grosor = 4 cm*/

                var expectedProp1 = new ProductDetailsResult("diametro", "25 cm", 2);
                var expectedProp2 = new ProductDetailsResult("grosor", "4 cm", 2);

                var actual = ProductService.getProductDetails(productId);
                

                Assert.AreEqual(expectedProp1, actual.First());
                Assert.AreEqual(expectedProp2, actual.Last());

                // transaction.Complete() no se llama, para que se ejecute el Rollback.
            }
        }


       


        #region Additional test attributes

        //Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize]
        public static void MyClassInitialize(TestContext testContext)
        {
            kernel = TestManager.ConfigureNInjectKernel();

            PropertyDao = kernel.Get<IPropertyDaoEF>();
            ProductDao = kernel.Get<IProductDaoEF>();
            CategoryDao = kernel.Get<ICategoryDaoEF>();
            ProductService = kernel.Get<IProductService>();
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

