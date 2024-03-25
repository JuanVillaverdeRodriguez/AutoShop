using Es.Udc.DotNet.ModelUtil.IoC;
using System;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Es.Udc.DotNet.PracticaMaD.HTTP.Util.IoC;
using Es.Udc.DotNet.ModelUtil.Log;


namespace Es.Udc.DotNet.PracticaMaD.Web
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application.Lock();

            IIoCManager IoCManager = new IoCManagerNinject();
            IoCManager.Configure();

            Application["managerIoC"] = IoCManager;
            //LogManager.RecordMessage("NInject kernel container started", MessageType.Info);

            Application.UnLock();

        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //SessionManager.TouchSession(Context);

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}