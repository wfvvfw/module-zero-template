﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Abp.Web;
using Castle.Facilities.Logging;

namespace AbpCompanyName.AbpProjectName.WebMetronicGms {

    public class MvcApplication : AbpWebApplication {
       
        protected override void Application_Start(object sender, EventArgs e) {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            base.Application_Start(sender, e);
        }

    }
}
