﻿<%@ Application Language="C#" %>
<%@ Import Namespace="ChinookWebSite" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace="ChinookSystem.Security" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);

        //Load the startup roles for Chinook
        var roleManager = new RoleManager();
        roleManager.AddStartupRoles();

        //Load the webmaster roles for Chinook
        var userManager = new UserManager();
        userManager.AddWebmaster();
    }

</script>
