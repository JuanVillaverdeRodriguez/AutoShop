using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*if (SessionManager.IsUserAuthenticated(Context))
            {
                Labellogged.Visible = true;
                Labellogged.Text = SessionManager.GetUsuarioSession(Context).Alias;
            }*/
            if (!IsPostBack)
            {
                UpdateNavbar();
            }
        }

        private void UpdateNavbar()
        {
            if (SessionManager.IsUserAuthenticated(Context))
            {
                // Usuario autenticado
                liSignIn.Visible = false;
                liCart.Visible = true;
                liOrders.Visible = true;
                liProfile.Visible = true;
                liLogout.Visible = true;
                Labellogged.Visible = true;
                Labellogged.Text = SessionManager.GetUsuarioSession(Context).Alias;

            }
            else
            {
                // Usuario no autenticado
                liSignIn.Visible = true;
                liCart.Visible = false;
                liOrders.Visible = false;
                liProfile.Visible = false;
                liLogout.Visible = false;
                Labellogged.Visible = false;
            }
        }


    }
}