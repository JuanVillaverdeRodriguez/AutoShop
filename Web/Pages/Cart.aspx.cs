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

            List<(long, int)> productsIds = new List<(long, int)>();

            if (!IsPostBack)
            {
                if (!SessionManager.IsUserAuthenticated(Context))
                {
                    Response.Redirect(Response.ApplyAppPathModifier("~/Pages/SignIn.aspx"));
                }

                UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);
                List<CartProduct> cartProducts = usuarioSession.UserCart.GetCartProducts();

                ListView1.DataSource = cartProducts;
                ListView1.DataBind();


                updateTotalPrice(cartProducts);
            }
            /*else
            {
                UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);
                List<CartProduct> cartProducts = usuarioSession.UserCart.GetCartProducts();

                updateTotalPrice(cartProducts);
            }*/
        }

        private void updateTotalPrice(List<CartProduct> cartProducts)
        {
            double totalPrice = 0;
            foreach (CartProduct cartProduct in cartProducts)
            {
                totalPrice += cartProduct.Price * cartProduct.Quantity;
            }

            paragraphTotalPrice.InnerText = "Precio total: " + totalPrice.ToString();
            if (totalPrice == 0)
            {
                ButtonTramitarId.Enabled = false;
            }
            else
            {
                ButtonTramitarId.Enabled = true;
            }

            
        }

        protected void buttonAdd_Click(object sender, EventArgs e)
        {
            // Buscar en el listView el producto a modificar
            Button button = sender as Button;
            int index = Convert.ToInt32(button.CommandArgument);
            ListViewDataItem item = ListView1.Items[index];

            // Encontrar el productId para buscarlo en el carrito
            Label productId = item.FindControl("productId") as Label;
            long productIdLong = long.Parse(productId.Text);

            // Obtener referencia a carrito
            UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);
            List<CartProduct> cartProducts = usuarioSession.UserCart.GetCartProducts();
            
            // Buscar el producto en el carrito
            CartProduct cartProductToAdd = cartProducts.Find(p => p.ProductId == productIdLong);

            if (cartProductToAdd.Quantity + 1 <= cartProductToAdd.Stock)
            {
                // Añadirlo al carrito
                usuarioSession.UserCart.AddProduct(cartProductToAdd);

                // Actualizar label de cantidad de unidades añadidas
                Label productCount = item.FindControl("productCount") as Label;
                productCount.Text = cartProductToAdd.Quantity.ToString();

                // Actualiza el precio total del carrito
                updateTotalPrice(cartProducts);
            }
        }

        protected void buttonSubstract_Click(object sender, EventArgs e)
        {
            // Buscar en el listView el producto a modificar
            Button button = sender as Button;
            int index = Convert.ToInt32(button.CommandArgument);
            ListViewDataItem item = ListView1.Items[index];

            // Encontrar el productId para buscarlo en el carrito
            Label productId = item.FindControl("productId") as Label;
            long productIdLong = long.Parse(productId.Text);

            // Obtener referencia a carrito
            UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);
            List<CartProduct> cartProducts = usuarioSession.UserCart.GetCartProducts();

            // Buscar el producto en el carrito
            CartProduct cartProductToAdd = cartProducts.Find(p => p.ProductId == productIdLong);

            // Substraerlo del carrito
            usuarioSession.UserCart.SubstractProduct(cartProductToAdd);

            // Actualizar label de cantidad de unidades añadidas
            Label productCount = item.FindControl("productCount") as Label;
            productCount.Text = cartProductToAdd.Quantity.ToString();

            // Actualiza el precio total del carrito
            updateTotalPrice(cartProducts);

            // Si hay 0 de ese producto, se elimina de la ListView
            if (cartProductToAdd.Quantity <= 0)
            {
                ListView1.Items.Remove(item); 
                ListView1.DataBind();
            }

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