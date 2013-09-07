using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Web.Routing;
using Microsoft.AspNet.SignalR;
using System.Timers;


namespace daggersRage
{
    public class Global : System.Web.HttpApplication
    {

        Timer physicsTimer;
        Timer updateTimer;

        protected void Application_Start(object sender, EventArgs e)
        {

            RouteTable.Routes.MapHubs();

            physicsTimer = new Timer(25); //was 40
            physicsTimer.Enabled = true;
            physicsTimer.Elapsed += new ElapsedEventHandler(DaggersRage.Update);

            updateTimer = new Timer(100); //45
            updateTimer.Enabled = true;
            updateTimer.Elapsed += new ElapsedEventHandler(DaggersRage.SendState);

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        


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