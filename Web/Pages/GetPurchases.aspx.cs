using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class GetPurchases : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Si es la primera entrada...
            {
                if (!SessionManager.IsUserAuthenticated(Context))
                {
                    Response.Redirect(Response.ApplyAppPathModifier("~/Pages/SignIn.aspx"));
                }

                IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

                IPurchaseService purchaseService = iocManager.Resolve<IPurchaseService>();

                List<PurchaseInfoResult> purchases = purchaseService.GetPurchases(SessionManager.GetUsuarioSession(Context).UserProfileId);

                ListView1.DataSource = purchases;
                ListView1.DataBind();

            }
        }
    }
}