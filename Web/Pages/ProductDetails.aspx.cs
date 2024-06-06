using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.Services.DTOs;
using Es.Udc.DotNet.PracticaMaD.Model.Services.ProductService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadProductDetails();
            }
        }

        private void LoadProductDetails()
        {
            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];
            IProductService productService = iocManager.Resolve<IProductService>();

            long productId = -1;
            try
            {
                productId = long.Parse(Request.Params.Get("id"));
                ProductResult productResult = productService.findProductById(productId);

                ProductName.Text = productResult.name;
                ProductPrice.Text = productResult.price.ToString();
                ProductStock.Text = productResult.stock.ToString();
                ProductImage.ImageUrl = "~/Imagenes/" + productResult.name + ".jpg";
            }
            catch (Exception)
            {
                // Habria que manejar la excepción
            }

            // Rellenar propiedades del producto
            if (productId != -1)
            {
                var productDetails = productService.getProductDetails(productId);
                foreach (var productDetailsResult in productDetails)
                {
                    var newLi = new HtmlGenericControl("li")
                    {
                        InnerText = productDetailsResult.propertyName + ": " + productDetailsResult.propertyValue
                    };
                    DetailsList.Controls.Add(newLi);
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);

            long productId = long.Parse(Request.Params.Get("id"));

            if (!SessionManager.IsUserAuthenticated(Context))
            {
                Response.Redirect(Response.ApplyAppPathModifier("~/Pages/SignIn.aspx"));
            }

            CartProduct cartProduct = new CartProduct(productId, ProductName.Text, Convert.ToDouble(ProductPrice.Text), 1, Convert.ToInt32(ProductStock.Text));

            string message = "";
            string isError = "";
            if (usuarioSession.UserCart.GetQuantity(cartProduct) + 1 <= Convert.ToInt32(ProductStock.Text))
            {
                usuarioSession.UserCart.AddProduct(cartProduct);
                message = "Producto añadido correctamente al carrito.";
            }
            else
            {
                message = "No se pudo añadir el producto al carrito. Existencias agotadas.";
                isError = "error";
            }

            ScriptManager.RegisterStartupScript(this, GetType(), "showNotification", $"showNotification('{message}', '{isError}');", true);
        }
    }
}
