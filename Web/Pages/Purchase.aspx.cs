﻿using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model;
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
    public partial class Purchase : System.Web.UI.Page
    {
        string SelectedType = "";

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                

                // Añade los años desde el actual hasta 10 años más adelante
                for (int i = DateTime.Now.Year; i <= DateTime.Now.Year + 10; i++)
                {
                    ddlYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }


            }
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