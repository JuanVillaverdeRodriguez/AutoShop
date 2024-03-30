using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class AddCard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //IIoCManager => Contenedor de dependencias
            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

            // 2) Obtener el servicio (UsuarioService)

            IUsuarioService usuarioService = iocManager.Resolve<IUsuarioService>();






        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //IIoCManager => Contenedor de dependencias
            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

            // 2) Obtener el servicio (UsuarioService)

            IUsuarioService usuarioService = iocManager.Resolve<IUsuarioService>();

            long cardNumber = long.Parse(TextBoxNumeroTarjeta.Text);
            int csv = int.Parse(TextBoxCSV.Text);
            String type = TextBoxTIPO.Text;
            DateTime expirationDate = DateTime.Now.AddDays(30);

            try
            {
                usuarioService.CreateCard(cardNumber, 1, type, csv, expirationDate);
                this.LabelTarjetaCreada.Visible = true;

            }
            catch
            {
                this.LabelTarjetaNoCreada.Visible = true;

            }
        }

    }
}