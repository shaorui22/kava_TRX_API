using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace TRX_KAVA_API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();   //在程序开始的地方(如Global\program)------注册log4net config。
            GlobalConfiguration.Configure(WebApiConfig.Register);

            LogHelper.Info("TRX API start!");
            LogHelper.Error("Start No Exception.");
        }
    }
}
