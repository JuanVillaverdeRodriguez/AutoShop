using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.Services.DTOs;
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
                if (!SessionManager.IsUserAuthenticated(Context))
                {
                    Response.Redirect(Response.ApplyAppPathModifier("~/Pages/SignIn.aspx"));
                }

                LoadCartProducts();
            }
        }

        private void LoadCartProducts()
        {
            UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);
            List<CartProduct> cartProducts = usuarioSession.UserCart.GetCartProducts();

            ListView1.DataSource = cartProducts;
            ListView1.DataBind();

            updateTotalPrice(cartProducts);
        }

        private void updateTotalPrice(List<CartProduct> cartProducts)
        {
            double totalPrice = 0;
            foreach (CartProduct cartProduct in cartProducts)
            {
                totalPrice += cartProduct.Price * cartProduct.Quantity;
            }

            paragraphTotalPrice.InnerText = "Precio total: " + totalPrice.ToString() + "€";
            ButtonTramitarId.Enabled = totalPrice > 0;
        }

        protected void buttonAdd_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int index = Convert.ToInt32(button.CommandArgument);
            ListViewDataItem item = ListView1.Items[index];

            Label productId = item.FindControl("productId") as Label;
            long productIdLong = long.Parse(productId.Text);

            UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);
            List<CartProduct> cartProducts = usuarioSession.UserCart.GetCartProducts();

            CartProduct cartProductToAdd = cartProducts.Find(p => p.ProductId == productIdLong);

            if (cartProductToAdd.Quantity + 1 <= cartProductToAdd.Stock)
            {
                usuarioSession.UserCart.AddProduct(cartProductToAdd);

                cartProducts = usuarioSession.UserCart.GetCartProducts();
                ListView1.DataSource = cartProducts;
                ListView1.DataBind();

                updateTotalPrice(cartProducts);
            }
        }

        protected void buttonSubstract_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int index = Convert.ToInt32(button.CommandArgument);
            ListViewDataItem item = ListView1.Items[index];

            Label productId = item.FindControl("productId") as Label;
            long productIdLong = long.Parse(productId.Text);

            UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);
            List<CartProduct> cartProducts = usuarioSession.UserCart.GetCartProducts();

            CartProduct cartProductToSubstract = cartProducts.Find(p => p.ProductId == productIdLong);

            usuarioSession.UserCart.SubstractProduct(cartProductToSubstract);

            cartProducts = usuarioSession.UserCart.GetCartProducts();
            ListView1.DataSource = cartProducts;
            ListView1.DataBind();

            updateTotalPrice(cartProducts);
        }

        protected void TramitarPedido(object sender, EventArgs e)
        {
            Response.Redirect(Response.ApplyAppPathModifier("~/Pages/Purchase.aspx"));
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
