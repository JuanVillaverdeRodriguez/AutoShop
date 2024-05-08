using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CardDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.CategoryDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.ProductDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PropertyDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.PurchaseLineDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.UsuarioDao;
using Es.Udc.DotNet.PracticaMaD.Model.DAOs.WorkshopDao;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Cart;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService;
using Ninject;
using System.Configuration;
using System.Data.Entity;

namespace Es.Udc.DotNet.PracticaMaD.HTTP.Util.IoC
{
    internal class IoCManagerNinject : IIoCManager
    {
        private static IKernel kernel;
        private static NinjectSettings settings;

        public void Configure()
        {
            settings = new NinjectSettings() { LoadExtensions = true };
            kernel = new StandardKernel(settings);

            /* UserProfileDao */
            kernel.Bind<IUsuarioDaoEF>().
                To<UsuarioDaoEF>();

            kernel.Bind<ICardDaoEF>().
                To<CardDaoEF>();

            kernel.Bind<IWorkshopDaoEF>().
                To<WorkshopDaoEF>();

            kernel.Bind<IProductDaoEF>().
                To<ProductDaoEF>();

            kernel.Bind<ICategoryDaoEF>().
                To<CategoryDaoEF>();

            kernel.Bind<IPropertyDaoEF>().
                To<PropertyDaoEF>();

            kernel.Bind<IPurchaseDaoEF>().
                To<PurchaseDaoEF>();

            kernel.Bind<IPurchaseLineDaoEF>().
                To<PurchaseLineDaoEF>();

            /* UserService */
            kernel.Bind<IUsuarioService>().
                To<UsuarioService>();

            kernel.Bind<IProductService>().
                To<ProductService>();

            kernel.Bind<IPurchaseService>().
                To<PurchaseService>();


            /* DbContext */
            string connectionString =
                ConfigurationManager.ConnectionStrings["practicamadEntities"].ConnectionString;

            kernel.Bind<DbContext>().
                ToSelf().
                InSingletonScope().
                WithConstructorArgument("nameOrConnectionString", connectionString);
        }

        public T Resolve<T>()
        {
            return kernel.Get<T>();
        }
    }
}