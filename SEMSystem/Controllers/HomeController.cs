using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEMSystem.Models;
using DNTBreadCrumb.Core;


namespace SEMSystem.Controllers
{
    [Authorize]
    [BreadCrumb(Title = "Home", UseDefaultRouteUrl = true, Order = 0, IgnoreAjaxRequests = true)]
    public class HomeController : Controller
    {


        private readonly SEMSystemContext _context;

        public HomeController(SEMSystemContext context)
        {
            _context = context;
        }




        [BreadCrumb(Title = "Index", Order = 1, IgnoreAjaxRequests = true)]
        public IActionResult Index()
        {



            return View();
        }


        [BreadCrumb(Title = "Posts List", Order = 3, IgnoreAjaxRequests = true)]
        public ActionResult Posts()
        {
            //this.SetCurrentBreadCrumbTitle("dynamic title 1");

            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "Wikis",
                Url = string.Format("{0}?id=1", Url.Action("Index", "Home", values: new { area = "" })),
                Order = 1
            });
            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "Lab",
                Url = string.Format("{0}?id=2", Url.Action("Index", "Home", values: new { area = "" })),
                Order = 2
            });

            return View();
        }


        public IActionResult SampleLayout()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
