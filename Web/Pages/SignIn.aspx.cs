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
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

            this.LabelUsuarioLogueado.Visible = false;
            this.LabelCredencialesIncorrectas.Visible = false;
            String loginName = TxtBoxUserName.Text;
            String password = TxtBoxPassword.Text;

            try
            {
                SignInResult result = SessionManager.Login(Context, loginName, password);
                this.LabelUsuarioLogueado.Visible = true;

                Response.Redirect(Response.ApplyAppPathModifier("~/Pages/MainPage.aspx"));

            }
            catch
            {
                this.LabelCredencialesIncorrectas.Visible = true;
            }



        }



    }
}