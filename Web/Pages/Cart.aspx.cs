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
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

                IProductService productService = iocManager.Resolve<IProductService>();

                UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);

                List<(long productId, int count)> cartProducts = usuarioSession.UserCart.GetProductsTupleList();

                List<ProductResult> productResults = new List<ProductResult>();

                foreach((long productId, int count) in cartProducts)
                {
                    // Esto esta muy mal hecho, demasiadas llamadas a la BBDD
                    // Hacer otro DTO para los productos en el carrito??
                    productResults.Append(productService.findProductById(productId));
                }

                ListView1.DataSource = productResults;
                ListView1.DataBind();


            }

        }
        protected string FormatName(object name)
        {
            if (name != null)
            {
                return "../Imagenes/" + name.ToString().Replace(" ", "%20") + ".jpg";
            }
            return string.Empty;
        }
    }

    
}