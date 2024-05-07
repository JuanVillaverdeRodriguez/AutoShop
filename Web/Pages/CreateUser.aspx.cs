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
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // 1) Obtener contexto de inyeccion de dependencias

            //IIoCManager => Contenedor de dependencias
            IIoCManager iocManager = (IIoCManager) Application["managerIoC"];

            // 2) Obtener el servicio (UsuarioService)

            IUsuarioService usuarioService = iocManager.Resolve<IUsuarioService>();

            // 3) LLamada al caso de uso (Leer parametros y actualizacion de vista)
            this.LabelUserCreated.Visible = false;
            this.LabelUserAlreadyCreated.Visible = false;
            String loginName = TxtBoxUserName.Text;
            String password = TxtBoxPassword.Text;
            String user_name = TxtBoxNombre.Text;
            String user_apellido = TextBoxApellidos.Text;
            String email = TextBoxEmail.Text;
            String idioma = TextBoxLanguage.Text;
            String country = TextBoxLanguage.Text; // TODO: arreglar

            long workshopId = long.Parse(TextBoxWorkshopId.Text);

            
            try
            {
                UserProfileDetails details;
                if (idioma == "")
                {
                    details = new UserProfileDetails(user_name, user_apellido, email, country, workshopId);
                }
                    
                else
                    details = new UserProfileDetails(user_name, user_apellido, email, idioma, country, workshopId);

                usuarioService.RegisterUsuario(loginName, password, details);
                this.LabelUserCreated.Visible = true;

                Response.Redirect(Response.ApplyAppPathModifier("~/Pages/MainPage.aspx"));


            }
            catch (Exception)
            {
                this.LabelUserAlreadyCreated.Visible = true;
            }
        }
    }
}