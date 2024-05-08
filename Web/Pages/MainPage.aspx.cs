using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class MainPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            this.CheckLogin.Visible = true;

            
            if (!IsPostBack) // Si es la primera entrada...
            {
                this.CheckLogin.Text +=  "PRIMERA VEZ";
                IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

                IProductService productService = iocManager.Resolve<IProductService>();

                List<ProductResult> products = productService.findProduct("");

                //labelList.Capacity = products.Count;

                foreach(ProductResult productResult in products)
                {

                }

                ListView1.DataSource = products;
                ListView1.DataBind();
            }
            else
            {
                this.CheckLogin.Text += "OTRA VEZ";
            }











            if (SessionManager.IsUserAuthenticated(Context))
            {

                // 2) Obtener el servicio (UsuarioService)


                UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);

                this.CheckLogin.Text = usuarioSession.UserProfileId.ToString();


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected string FormatName(object name)
        {
            if (name != null)
            {
                return "../Imagenes/" + name.ToString().Replace(" ", "%20")+".jpg";
            }
            return string.Empty;
        }

    }
}