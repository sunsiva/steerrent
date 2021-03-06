﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using SteerRent;

namespace SteerRent
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterOpenAuth();

            RegisterRoutes(RouteTable.Routes);
        }

        void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Login", "SteerRent", "~/Views/Account/Login.aspx");
            routes.MapPageRoute("ForgotPassword", "SteerRent", "~/Views/Account/ForgotPassword.aspx");
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs
            this.Context.Response.Redirect("~/Views/Account/Login.aspx"); 

        }
    }
}
