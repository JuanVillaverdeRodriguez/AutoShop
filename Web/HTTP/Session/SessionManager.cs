using Es.Udc.DotNet.PracticaMaD.Web.HTTP.View.ApplicationObjects;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.IoC;
using System;
using System.Web;
using System.Web.Security;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.Cart;

namespace Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session
{
    public class SessionManager
    {
        public static readonly String LOCALE_SESSION_ATTRIBUTE = "locale";

        public static readonly String USER_SESSION_ATTRIBUTE =
               "userSession";


        private static IUsuarioService usuarioService;

        private static IProductService productService;

        private static IPurchaseService purchaseService;


        public IUsuarioService UsuarioService
        {
            set { usuarioService = value; }
        }

        public IProductService ProductService
        {
            set { productService = value; }
        }
        public IPurchaseService PurchaseService
        {
            set { purchaseService = value; }
        }

        static SessionManager()
        {
            IIoCManager iocManager =
                (IIoCManager)HttpContext.Current.Application["managerIoC"];

            usuarioService = iocManager.Resolve<IUsuarioService>();
            productService = iocManager.Resolve<IProductService>();
            purchaseService = iocManager.Resolve<IPurchaseService>();

        }
        public static void RegisterUser(HttpContext context,
            String alias, String password,
            UserProfileDetails userProfileDetails)
        {
            long usuarioId = usuarioService.RegisterUsuario(alias, password,
                userProfileDetails);

            UsuarioSession userSession = new UsuarioSession();
            userSession.UserProfileId = usuarioId;

            Locale locale = new Locale(userProfileDetails.language,
                userProfileDetails.country);

            UpdateSessionForAuthenticatedUser(context, userSession, locale);

            FormsAuthentication.SetAuthCookie(alias, false);
        }


        /*public static void Login(HttpContext context, String alias,
           String password, bool isAuth20)
        {
            LoginResult loginResult;
            if (isAuth20)
            {
                 loginResult = DoLogin(context, loginName,
                    clearPassword, true, rememberMyPassword);
            }
            else
            {
                 loginResult = DoLogin(context, loginName,
                    clearPassword, false, rememberMyPassword);
            }
            

            if (rememberMyPassword)
            {
                CookiesManager.LeaveCookies(context, loginName,
                    loginResult.EncryptedPassword);
            }
        }*/

        public static SignInResult Login(HttpContext context,
             String alias, String password)
        {
            SignInResult loginResult =
                usuarioService.SignIn(alias, password);

            /* Insert necessary objects in the session. */

            UsuarioSession usuarioSession = new UsuarioSession();
            usuarioSession.UserProfileId = loginResult.user_id;
            usuarioSession.UserCart = new Cart();

            Locale locale =
                new Locale(loginResult.language, loginResult.country);

            UpdateSessionForAuthenticatedUser(context, usuarioSession, locale);

            return loginResult;
        }


        private static void UpdateSessionForAuthenticatedUser(
            HttpContext context, UsuarioSession usuarioSession, Locale locale)
        {
            /* Insert objects in session. */
            context.Session.Add(USER_SESSION_ATTRIBUTE, usuarioSession);
            context.Session.Add(LOCALE_SESSION_ATTRIBUTE, locale);
        }

        public static Boolean IsUserAuthenticated(HttpContext context)
        {
            if (context.Session == null)
                return false;

            return (context.Session[USER_SESSION_ATTRIBUTE] != null);
        }

        public static Locale GetLocale(HttpContext context)
        {
            Locale locale =
                (Locale)context.Session[LOCALE_SESSION_ATTRIBUTE];

            return locale;
        }

        public static void UpdateUsuarioProfileDetails(HttpContext context,
            UserProfileDetails userProfileDetails)
        {

            UsuarioSession userSession =
                (UsuarioSession)context.Session[USER_SESSION_ATTRIBUTE];

            usuarioService.UpdateUsuarioDetails(userSession.UserProfileId,
                userProfileDetails);


            Locale locale = new Locale(userProfileDetails.language,
                userProfileDetails.country);

            UpdateSessionForAuthenticatedUser(context, userSession, locale);
        }

        public static UserProfileDetails FindUsuarioProfileDetails(HttpContext context)
        {
            UsuarioSession userSession =
                (UsuarioSession)context.Session[USER_SESSION_ATTRIBUTE];

            UserProfileDetails userProfileDetails =
                usuarioService.FindUsuarioDetails(userSession.UserProfileId);

            return userProfileDetails;
        }

        public static UsuarioSession GetUsuarioSession(HttpContext context)
        {
            if (IsUserAuthenticated(context))
                return (UsuarioSession)context.Session[USER_SESSION_ATTRIBUTE];
            else
                return null;
        }


        public static void Logout(HttpContext context)
        {
            context.Session.Abandon();

            FormsAuthentication.SignOut();
        }

    }
}