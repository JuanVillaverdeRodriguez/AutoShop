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

        private void BindListView()
        {
            ListView1.DataBind();
            Buscar();
        }

        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            BindListView();
        }

        protected void Button_Search(object sender, EventArgs e)
        {
            Buscar();
        }

        private void Buscar()
        {
            IIoCManager iocManager = (IIoCManager)Application["managerIoC"];

            IProductService productService = iocManager.Resolve<IProductService>();

            String name = TextBoxBusqueda.Text;

            List<ProductResult> products;

            ListItem selectedListItem = ddlCategory.SelectedItem;

            SelectedCategory = selectedListItem.Value;

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