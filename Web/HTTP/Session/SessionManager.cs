using Es.Udc.DotNet.PracticaMaD.Web.HTTP.View.ApplicationObjects;
using Es.Udc.DotNet.ModelUtil.Exceptions;
using Es.Udc.DotNet.ModelUtil.IoC;
using System;
using System.Web;
using System.Web.Security;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService;

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

        public static void Login(HttpContext context, String alias,
           String password, bool isAuth20)
        {
            /* Try to login, and if successful, update session with the necessary
             * objects for an authenticated user. */
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
            

            /* Add cookies if requested. */
            if (rememberMyPassword)
            {
                CookiesManager.LeaveCookies(context, loginName,
                    loginResult.EncryptedPassword);
            }
        }

        private static UserProfileDetails DoLogin(HttpContext context,
             String alias, String password)
        {
            UserProfileDetails loginResult =
                usuarioService.SignIn(alias, password);

            /* Insert necessary objects in the session. */

            UsuarioService userSession = new UsuarioService();
            userSession.UserProfileId = loginResult.UserProfileId;

            Locale locale =
                new Locale(loginResult.Language, loginResult.Country);

            UpdateSessionForAuthenticatedUser(context, userSession, locale);

            return loginResult;
        }

        /// <summary>
        /// Updates the session values for an previously authenticated user
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        /// <param name="userSession">The user data stored in session.</param>
        /// <param name="locale">The locale info.</param>
        private static void UpdateSessionForAuthenticatedUser(
            HttpContext context, UserSession userSession, Locale locale)
        {
            /* Insert objects in session. */
            context.Session.Add(USER_SESSION_ATTRIBUTE, userSession);
            context.Session.Add(LOCALE_SESSION_ATTRIBUTE, locale);
        }

        /// <summary>
        /// Determine if a user is authenticated
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        /// <returns>
        /// 	<c>true</c> if is user authenticated
        ///     <c>false</c> otherwise
        /// </returns>
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

        /// <summary>
        /// Updates the user profile details.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="userProfileDetails">The user profile details.</param>
        public static void UpdateUserProfileDetails(HttpContext context,
            UserProfileDetails userProfileDetails)
        {
            /* Update user's profile details. */

            UserSession userSession =
                (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            usuarioService.UpdateUserProfileDetails(userSession.UserProfileId,
                userProfileDetails);

            /* Update user's session objects. */

            Locale locale = new Locale(userProfileDetails.Language,
                userProfileDetails.Country);

            userSession.FirstName = userProfileDetails.FirstName;

            UpdateSessionForAuthenticatedUser(context, userSession, locale);
        }

        /// <summary>
        /// Finds the user profile with the id stored in the session.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static UserProfileDetails FindUserProfileDetails(HttpContext context)
        {
            UserSession userSession =
                (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            UserProfileDetails userProfileDetails =
                usuarioService.FindUserProfileDetails(userSession.UserProfileId);

            return userProfileDetails;
        }

        //Tengo que añadir alguna variable para indicar cuantos elementos quiero sacar de la BBDD para los posts
        public static FeedUserDetails findFeedUserDetails(HttpContext context)
        {
            UserSession userSession =
                (UserSession)context.Session[USER_SESSION_ATTRIBUTE];
            int size = Settings.Default.PracticaMaD_defaultSize;

            FeedUserDetails feedUserDetails =
                productService.FindFeedUserDetails(userSession.UserProfileId, 0, size);

            return feedUserDetails;
        }

        /// <summary>
        /// Gets the user info stored in the session.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns></returns>
        public static UserSession GetUserSession(HttpContext context)
        {
            if (IsUserAuthenticated(context))
                return (UserSession)context.Session[USER_SESSION_ATTRIBUTE];
            else
                return null;
        }

        /// <summary>
        /// Changes the user's password
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        /// <param name="oldClearPassword">The old password in clear text</param>
        /// <param name="newClearPassword">The new password in clear text</param>
        /// <exception cref="IncorrectPasswordException"/>
        public static void ChangePassword(HttpContext context,
               String oldClearPassword, String newClearPassword)
        {
            UserSession userSession =
                (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

            usuarioService.ChangePassword(userSession.UserProfileId,
                oldClearPassword, newClearPassword);

            /* Remove cookies. */
            CookiesManager.RemoveCookies(context);
        }

        /// <summary>
        /// Destroys the session, and removes the cookies if the user had
        /// selected "remember my password".
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        public static void Logout(HttpContext context)
        {
            /* Remove cookies. */
            CookiesManager.RemoveCookies(context);

            /* Invalidate session. */
            context.Session.Abandon();

            /* Invalidate Authentication Ticket */
            FormsAuthentication.SignOut();
        }

        /// <sumary>
        /// Guarantees that the session will have the necessary objects if the
        /// user has been authenticated or had selected "remember my password"
        /// in the past.
        /// </sumary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        public static void TouchSession(HttpContext context)
        {
            /* Check if "UserSession" object is in the session. */
            UserSession userSession = null;

            if (context.Session != null)
            {
                userSession =
                    (UserSession)context.Session[USER_SESSION_ATTRIBUTE];

                // If userSession object is in the session, nothing should be doing.
                if (userSession != null)
                {
                    return;
                }
            }

            /*
             * The user had not been authenticated or his/her session has
             * expired. We need to check if the user has selected "remember my
             * password" in the last login (login name and password will come
             * as cookies). If so, we reconstruct user's session objects.
             */
            UpdateSessionFromCookies(context);
        }

        /// <summary>
        /// Tries to login (inserting necessary objects in the session) by using
        /// cookies (if present).
        /// </summary>
        /// <param name="context">Http Context includes request, response, etc.</param>
        private static void UpdateSessionFromCookies(HttpContext context)
        {
            HttpRequest request = context.Request;
            if (request.Cookies == null)
            {
                return;
            }

            /*
             * Check if the login name and the encrypted password come as
             * cookies.
             */
            String loginName = CookiesManager.GetLoginName(context);
            String encryptedPassword = CookiesManager.GetEncryptedPassword(context);

            if ((loginName == null) || (encryptedPassword == null))
            {
                return;
            }

            /* If loginName and encryptedPassword have valid values (the user selected "remember
             * my password" option) try to login, and if successful, update session with the
             * necessary objects for an authenticated user.
             */
            try
            {
                DoLogin(context, loginName, encryptedPassword, true, true);

                /* Authentication Ticket. */
                FormsAuthentication.SetAuthCookie(loginName, true);
            }
            catch (Exception)
            { // Incorrect loginName or encryptedPassword
                return;
            }
        }
    }
}