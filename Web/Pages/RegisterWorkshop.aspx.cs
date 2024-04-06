using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model.Services.UsuarioService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Es.Udc.DotNet.PracticaMaD.Web.Pages
{
    public partial class RegisterWorkshop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // 1) Obtener contexto de inyeccion de dependencias

            //IIoCManager => Contenedor de dependencias
            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

            // 2) Obtener el servicio (UsuarioService)

            IUsuarioService usuarioService = iocManager.Resolve<IUsuarioService>();

            // 3) LLamada al caso de uso (Leer parametros y actualizacion de vista)
            this.LabelUserCreated.Visible = false;
            this.LabelUserAlreadyCreated.Visible = false;
            String WorkshopName = TxtBoxWorkshopName.Text;
            String Country = TxtBoxCountry.Text;
            int PostalCode = int.Parse(TxtBoxPostalCode.Text);
            try
            {
                usuarioService.RegisterWorkshop(
                                                PostalCode,
                                                WorkshopName);
                this.LabelUserCreated.Visible = true;


            }
            catch (Exception)
            {
                this.LabelUserAlreadyCreated.Visible = true;
            }
        }
    }
}