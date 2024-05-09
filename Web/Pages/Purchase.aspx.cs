using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.Services.PurchaseService;
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
    public partial class Purchase : System.Web.UI.Page
    {

        long cardNumberSelected;

        int csvSelected;

        string typeSelected;

        string userIdSelected;

        bool defaultCardSelected;

        DateTime expirationDateSelected;


        Card selectedCard = new Card();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
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



                // Añade los años desde el actual hasta 10 años más adelante
                for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 10; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }
                List<Card> usuarioCards = usuarioService.findUsuarioCards(usuarioSession.UserProfileId);

                foreach (Card card in usuarioCards)
                {
                    Label labelCardNumber = new Label();
                    Label labelCSV = new Label();

                    System.Web.UI.HtmlControls.HtmlGenericControl divUserCard = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    divUserCard.ID = "divCard_" + card.card_number;

                    divUserCard.Style["border"] = "3px solid black";

                    // Establecer propiedades del Label
                    labelCardNumber.ID = "labelCardNumber" + card.card_number; // Establecer un ID único
                    labelCSV.Attributes["class"] = "labelCardNumber_Class";
                    labelCardNumber.Text = "CardNumber: " + card.card_number.ToString(); // Establecer el texto de la etiqueta

                    divUserCard.Attributes["class"] = "user-card";

                    labelCSV.ID = "labelCSV" + card.card_number;
                    labelCSV.Attributes["class"] = "labelCSV_Class";
                    labelCSV.Text = "CSV: " + card.csv.ToString();

                    divUserCard.Controls.Add(labelCardNumber);
                    divUserCard.Controls.Add(labelCSV);

                    divUserCard.Attributes["onclick"] = "divUserCard_Click";


                    divUserCardsId.Controls.Add(divUserCard);
                }
                

            }
        }

        protected void divUserCard_Click(object sender, EventArgs e)
        {
            var clickedDiv = (System.Web.UI.HtmlControls.HtmlGenericControl)sender;
            string divId = clickedDiv.ID;

            foreach (Control control in clickedDiv.Controls)
            {
                // Verificar si el control tiene la clase deseada
                if (control is Label label && label.CssClass == "tu-clase")
                {
                    // El control es una etiqueta con la clase deseada
                    // Puedes acceder y manipular el control aquí
                    // Por ejemplo, puedes establecer su texto:
                    label.Text = "Texto modificado";
                }
            }
        }

        protected void ButtonCreateNewCard(object sender, EventArgs e)
        {
            divCreateNewCardId.Visible = true;
            ButtonAddCardId.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

            IPurchaseService purchaseService = iocManager.Resolve<IPurchaseService>();

            UsuarioSession usuarioSession = SessionManager.GetUsuarioSession(Context);

            Card card = new Card();

            if (ddlYear.SelectedItem != null && ddlMonth.SelectedItem != null && ddlType.SelectedItem != null)
            {
                card.type = ddlType.SelectedItem.Value; // Tipo de tarjeta (Mastercard, Visa...)

                int year = int.Parse(ddlYear.SelectedItem.Value);
                int month = int.Parse(ddlMonth.SelectedItem.Value);

                DateTime dateTime = new DateTime(year, month, 1);
                card.expiration_date = dateTime; // Fecha de expiracion

                card.card_number = long.Parse(TextBoxNumeroTarjeta.Text); // Numero de tarjeta

                card.csv = int.Parse(TextBoxCSV.Text); // CSV

                card.defaultCard = CheckBoxDefaultCard.Checked; // Tarjeta default o no

                card.userId = usuarioSession.UserProfileId; // User id
            }

            int postalCode = int.Parse(TextBoxPostalCode.Text);

            purchaseService.Purchase(card, usuarioSession.UserCart, postalCode, TextBoxDescription.Text, CheckBoxIsUrgent.Checked);

        }
    }
}