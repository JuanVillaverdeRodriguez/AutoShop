using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                checkAuth();
                loadUserDetails();
            }
        }

        private void checkAuth()
        {
            if (!SessionManager.IsUserAuthenticated(Context))
            {
                Response.Redirect(Response.ApplyAppPathModifier("~/Pages/SignIn.aspx"));
            }
        }

        private void loadUserDetails()
        {
            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

            IUsuarioService usuarioService = iocManager.Resolve<IUsuarioService>();

            UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);

            UserProfileDetails userProfileDetails = usuarioService.FindUsuarioDetails(usuarioSession.UserProfileId);

            Name.Text = userProfileDetails.user_name;
            Surname.Text = userProfileDetails.user_surname;
            Email.Text = userProfileDetails.email;
            Language.Text = userProfileDetails.language;
            Country.Text = userProfileDetails.country;
            WorkshopId.Text = userProfileDetails.workshopId.ToString();
        }
        protected void buttonApply_click(object sender, EventArgs e)
        {
            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

            IUsuarioService usuarioService = iocManager.Resolve<IUsuarioService>();

            UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);

            UserProfileDetails userProfileDetails = new UserProfileDetails(Name.Text, Surname.Text, Email.Text, Language.Text, Country.Text, long.Parse(WorkshopId.Text));
            usuarioService.UpdateUsuarioDetails(usuarioSession.UserProfileId, userProfileDetails);
        }

        protected void buttonCancel_click(object sender, EventArgs e)
        {
            // Simplemente vuelve a cargar los detalles del usuario
            loadUserDetails();
        }


    }
}