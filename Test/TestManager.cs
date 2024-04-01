using Es.Udc.DotNet.PracticaMaD.Model.DAOs.UsuarioDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.WorkshopDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PropertyDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CardDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService;
using Ninject;
using System.Configuration;
using System.Data.Entity;

namespace Es.Udc.DotNet.PracticaMaD.Test
{
    public class TestManager
    {
        /// <summary>
        /// Configures and populates the Ninject kernel
        /// </summary>
        /// <returns>The NInject kernel</returns>
        public static IKernel ConfigureNInjectKernel()
        {
            NinjectSettings settings = new NinjectSettings() { LoadExtensions = true };

            IKernel kernel = new StandardKernel(settings);

            kernel.Bind<IUsuarioDaoEF>().
                To<UsuarioDaoEF>();
            kernel.Bind<ICardDaoEF>().
                To<CardDaoEF>();
            kernel.Bind<IWorkshopDaoEF>().
                To<WorkshopDaoEF>();
            kernel.Bind<ICategoryDaoEF>().
                To<CategoryDaoEF>();
            kernel.Bind<IProductDaoEF>().
                To<ProductDaoEF>();
            kernel.Bind<IPurchaseDaoEF>().
                To<PurchaseDaoEF>();
            kernel.Bind<IPropertyDaoEF>().
                To<PropertyDaoEF>();

            kernel.Bind<IUsuarioService>().
                To<UsuarioService>();
            kernel.Bind<IProductService>().
                  To<ProductService>();
            kernel.Bind<IProductService>().
                To<ProductService>();

            string connectionString =
                ConfigurationManager.ConnectionStrings["practicamadEntities"].ConnectionString;

            kernel.Bind<DbContext>().
                ToSelf().
                InSingletonScope().
                WithConstructorArgument("nameOrConnectionString", connectionString);

            return kernel;
        }

        /// <summary>
        /// Configures the Ninject kernel from an external module file.
        /// </summary>
        /// <param name="moduleFilename">The module filename.</param>
        /// <returns>The NInject kernel</returns>
        public static IKernel ConfigureNInjectKernel(string moduleFilename)
        {
            NinjectSettings settings = new NinjectSettings() { LoadExtensions = true };
            IKernel kernel = new StandardKernel(settings);

            kernel.Load(moduleFilename);

            return kernel;
        }

        public static void ClearNInjectKernel(IKernel kernel)
        {
            kernel.Dispose();
        }
    }
}