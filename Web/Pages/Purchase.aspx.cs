using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService;
using Es.Udc.DotNet.PracticaMaD.Web.HTTP.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class Purchase : System.Web.UI.Page
    {

        Card selectedCard = new Card();

        Dictionary<string, Card> usuarioCardsDictionary;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                LabelPurchaseOkId.Visible = false;

                generarddls();
            }
        }

        protected void generarddls()
        {
            if (!SessionManager.IsUserAuthenticated(Context))
            {
                Response.Redirect(Response.ApplyAppPathModifier("~/Pages/SignIn.aspx"));
            }
            UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);


            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

            IPurchaseService purchaseService = iocManager.Resolve<IPurchaseService>();

            IUsuarioService usuarioService = iocManager.Resolve<IUsuarioService>();


            divCreateNewCardId.Visible = false;
            ButtonAddCardId.Visible = true;
            aceptar.Visible = false;
            LabelTarjetaNoCreada.Visible = false;


            // Añade los años desde el actual hasta 10 años más adelante
            for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 10; i++)
            {
                ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            List<CardInfoResult> usuarioCards = usuarioService.findUsuarioCards(usuarioSession.UserProfileId);

            ddlCard.Items.Clear();

            foreach (CardInfoResult card in usuarioCards)
            {
                ddlCard.Items.Add(new ListItem(card.cardNumber.ToString(), card.cardNumber.ToString()));
            }
        }

        protected void ButtonCreateNewCard(object sender, EventArgs e)
        {
            divCreateNewCardId.Visible = true;
            ButtonAddCardId.Visible = false;
            aceptar.Visible = true;

        }

        protected void ButtonAcceptNewCard(object sender, EventArgs e)
        {
            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

            IUsuarioService usuarioService = iocManager.Resolve<IUsuarioService>();

            UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);

            Card card = new Card();

            if (ddlYear.SelectedItem != null && ddlMonth.SelectedItem != null && ddlType.SelectedItem != null)
            {
                string type = ddlType.SelectedItem.Value; // Tipo de tarjeta (Mastercard, Visa...)

                int year = int.Parse(ddlYear.SelectedItem.Value);
                int month = int.Parse(ddlMonth.SelectedItem.Value);

                DateTime dateTime = new DateTime(year, month, 1);

                long card_number = long.Parse(TextBoxNumeroTarjeta.Text); // Numero de tarjeta

                int csv = int.Parse(TextBoxCSV.Text); // CSV

                long userId = usuarioSession.UserProfileId; // User id

                usuarioService.CreateCard(card_number, userId, type, csv, dateTime);

                generarddls();
            }
            else
            {
                LabelTarjetaNoCreada.Visible = true;
            }


            



        }

        protected void ButtonBuy_Click(object sender, EventArgs e)
        {
            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

            IPurchaseService purchaseService = iocManager.Resolve<IPurchaseService>();

            UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);

            int postalCode = int.Parse(TextBoxPostalCode.Text);

            ListItem selectedListItem = ddlCard.SelectedItem;

            long cardnumber = long.Parse(selectedListItem.Value);

            Card selectedCard = purchaseService.FindCardByCardNumber(cardnumber);


            try
            {
                purchaseService.Purchase(selectedCard, usuarioSession.UserCart, postalCode, TextBoxDescription.Text, CheckBoxIsUrgent.Checked);

                LabelPurchaseOkId.Visible = true;
            } catch (Exception)
            {

            }

        }
    }
}