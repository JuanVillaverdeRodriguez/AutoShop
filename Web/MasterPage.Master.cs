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
            if (SessionManager.IsUserAuthenticated(Context))
            {
                // Obtener una referencia al control de enlace usando su ID
                HtmlGenericControl sesionLink = (HtmlGenericControl)FindControl("Sesion");

                // Verificar si se encontró el elemento
                if (sesionLink != null)
                {
                    // Hacer que el enlace no sea visible
                    sesionLink.Style["display"] = "none";
                }
            }
        }
    }
}