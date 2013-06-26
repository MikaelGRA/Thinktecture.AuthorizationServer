﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thinktecture.AuthorizationServer.WebHost.Areas.UserApplications.Models;

namespace Thinktecture.AuthorizationServer.WebHost.Areas.UserApplications.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new UserApplicationsViewModel();
            return View(vm);
        }

        public JavaScriptResult Urls()
        {
            var path = Request.ApplicationPath;
            if (!path.EndsWith("/")) path += "/";
            path += "api/";

            var url = new Uri(Request.Url, path);
            var js = String.Format("if(userApps){{userApps.baseUrl='{0}';}}", url);

            return base.JavaScript(js);
        }
    }
}