using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

                IProductService productService = iocManager.Resolve<IProductService>();

                long productId = -1;
                try
                {
                    productId = long.Parse(Request.Params.Get("id"));
                    ProductResult productResult = productService.findProductById(productId);
                    ProductName.Text = productResult.name;
                    ProductImage.ImageUrl = "~/Imagenes/" + productResult.name + ".jpg";

                }
                catch (Exception)
                {

                }


                if (productId != -1)
                {
                    List<ProductDetailsResult> productDetails = productService.getProductDetails(productId);


                    foreach (ProductDetailsResult productDetailsResult in productDetails)
                    {
                        HtmlGenericControl newLi = new HtmlGenericControl("li");
                        newLi.InnerText = productDetailsResult.propertyName + ": " + productDetailsResult.propertyValue; // Establecer el texto del <li>
                        DetailsList.Controls.Add(newLi);
                    }
                }
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);

            long productId = long.Parse(Request.Params.Get("id"));
            usuarioSession.UserCart.AddProduct(productId);
            
        }
    }
}