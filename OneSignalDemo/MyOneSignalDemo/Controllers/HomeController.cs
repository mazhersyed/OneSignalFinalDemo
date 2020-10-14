using log4net;
using MyOneSignalDemo.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyOneSignalDemo.Helpers;

namespace MyOneSignalDemo.Controllers
{
    public class HomeController : Controller
    {
        OneSignalManager osm = new OneSignalManager();

        #region Default
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Login()
        {
            return View("~/Views/Account/Login.cshtml");
        }
        #endregion

        #region ViewApp
        [Authorize(Roles = WebHelpers.adminRole + "," + WebHelpers.userRole)]
        public ActionResult ViewApp()
        {
            if (!Request.IsAuthenticated)
                return View("~/Views/Account/Login.cshtml");
            var response = osm.ViewApps();

            return View(response);
        }
        #endregion

        #region CreateApp
        [Authorize(Roles = WebHelpers.adminRole)]
        public ActionResult CreateApp()
        {
            if (!Request.IsAuthenticated)
                return View("~/Views/Account/Login.cshtml");
            return View();

        }
        public ActionResult AppManagementCreate(OneSignalModel model)
        {
            osm.Create(model);
            return View("ViewApp", osm.ViewApps());
        }
        #endregion

        #region UpdateApp
        [Authorize(Roles = WebHelpers.adminRole)]
        public ActionResult UpdateApp(string id)
        {
            if (!Request.IsAuthenticated)
                return View("~/Views/Account/Login.cshtml");
            var response = osm.ViewApps(id);
            //if response has a record then return the record
            if (response.Count == 1)
            {
                ServiceResponse sR = response[0];
                return View(sR);
            }
            else
                return View("ViewApp", osm.ViewApps());

        }
        
        [HttpPost]
        public ActionResult AppManagementUpdate(ServiceResponse model)
        {
            osm.Update(model);
            return View("ViewApp", osm.ViewApps());
        }


        #endregion
    }
}