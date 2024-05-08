using Es.Udc.DotNet.ModelUtil.IoC;
using Es.Udc.DotNet.PracticaMaD.Model;
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
    public partial class MainPage : System.Web.UI.Page
    {
        string SelectedCategory = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Si es la primera entrada...
            {
                IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

                IProductService productService = iocManager.Resolve<IProductService>();

                List<ProductResult> products = productService.findProduct("");

                ListView1.DataSource = products;
                ListView1.DataBind();
            }
        }

        protected void Button_Search(object sender, EventArgs e)
        {
            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

            IProductService productService = iocManager.Resolve<IProductService>();

            String name = TextBoxBusqueda.Text;

            List<ProductResult> products;

            if (SelectedCategory == "")
            {
                products = productService.findProduct(name);
            }
            else
            {
                products = productService.findProduct(name, SelectedCategory);
            }

            ListView1.DataSource = products;
            ListView1.DataBind();
        }


        protected void Button_Filtrar(object sender, EventArgs e)
        {
            // Obtener el ListItem seleccionado del DropDownList
            ListItem selectedListItem = ddlCategory.SelectedItem;

            // Verificar si se seleccionó algún ListItem
            if (selectedListItem != null)
            {
                // Acceder a las propiedades del ListItem seleccionado
                SelectedCategory = selectedListItem.Value;
            }


            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

            IProductService productService = iocManager.Resolve<IProductService>();

            String name = TextBoxBusqueda.Text;

            List<ProductResult> products;

            if (SelectedCategory == "")
            {
                products = productService.findProduct("");
            }
            else
            {
                products = productService.findProduct("", SelectedCategory);
            }

            ListView1.DataSource = products;
            ListView1.DataBind();

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