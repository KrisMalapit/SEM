using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SEMSystem.Models;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

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

            ViewData["ID"] = 0;
            //ViewData["AreaId"] = new SelectList(_context.Areas, "ID", "Name");
            ViewData["BicycleId"] = new SelectList(_context.Bicycles, "ID", "IdentificationNo");
            ViewData["CreatedAt"] = DateTime.Now.Date.ToString("MM-dd-yyyy");

            ViewData["ReferenceIdFE"] = 0;
            ViewData["ReferenceIdEL"] = 0;
            ViewData["ReferenceIdIT"] = 0;
            ViewData["ReferenceIdFH"] = 0;
            ViewData["ReferenceIdB"] = 0;
            



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
