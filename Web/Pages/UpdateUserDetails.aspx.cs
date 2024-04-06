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
    public partial class UpdateUserDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

            IUsuarioService usuarioService = iocManager.Resolve<IUsuarioService>();

            this.LabelChangesApplied.Visible = false;
            String user_name = TxtBoxNombre.Text;
            String user_apellido = TextBoxApellidos.Text;
            String email = TextBoxEmail.Text;
            String idioma = TextBoxLanguage.Text;
            String country = TextBoxLanguage.Text;



            //Haría falta un userId sobre el que ejecutar los cambios (debería cojerlo la propia página del usuario autenticado) pondré por defecto el userId = 1
            long userId = 1;
            UserProfileDetails details;
            if (idioma == "")
                details = new UserProfileDetails(user_name, user_apellido, email, country, 0);
            else
                details = new UserProfileDetails(user_name, user_apellido, email, idioma, country, 0);

            usuarioService.UpdateUsuarioDetails(userId, details);
            this.LabelChangesApplied.Visible = true;
        }
    }
}