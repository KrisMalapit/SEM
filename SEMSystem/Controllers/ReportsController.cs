using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net.Http;
using System.Threading.Tasks;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using SEMSystem.Models;
using SEMSystem.Models.View_Model;

namespace SEMSystem.Controllers
{
    public class ReportsController : Controller
    {
        private readonly SEMSystemContext _context;

        public ReportsController(SEMSystemContext context)
        {
            _context = context;
        }
        [BreadCrumb(Title = "Index", Order = 1, IgnoreAjaxRequests = true)]
        public ActionResult Index()
        {
            this.SetCurrentBreadCrumbTitle("Reports");
            return View();
        }
        [HttpPost]
        public ActionResult getDataItemHistory(string strStart, string end, int AreaId)
        {
            string strFilter = "";
            try
            {
                DateTime startDate = DateTime.ParseExact(strStart, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                DateTime endDate = DateTime.ParseExact(end, "MM/dd/yyyy", CultureInfo.InvariantCulture);


                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;


                for (int i = 0; i < 5; i++)
                {
                    string colval = Request.Form["columns[" + i + "][search][value]"];
                    if (colval != "")
                    {
                        colval = colval.ToUpper();
                        string colSearch = Request.Form["columns[" + i + "][name]"];

                        if (strFilter == "")
                        {

                            strFilter = colSearch + ".ToString().ToUpper().Contains(" + "\"" + colval + "\"" + ")";

                        }
                        else
                        {
                            strFilter = strFilter + " && " + colSearch + ".ToString().ToUpper().Contains(" + "\"" + colval + "\"" + ")";
                        }

                    }
                }


                if (strFilter == "")
                {
                    strFilter = "true";
                }



                int recCount =
                     _context.LocationItemDetails
                    .Where(a => a.Status == "Active")
                    .Where(a => a.CreatedDate.Date >= startDate.Date && a.CreatedDate.Date <= endDate.Date)
                    .Select(a => new
                    {
                        Location = a.Equipment == "FE" ? _context.LocationFireExtinguishers.Where(b => b.Id == a.HeaderId).FirstOrDefault().Location :
                                               a.Equipment == "EL" ? _context.LocationEmergencyLights.Where(b => b.Id == a.HeaderId).FirstOrDefault().Location :
                                               a.Equipment == "FH" ? _context.LocationFireHydrants.Where(b => b.Id == a.HeaderId).FirstOrDefault().Location :
                                               _context.LocationInergenTanks.Where(b => b.Id == a.HeaderId).FirstOrDefault().Area,

                    })
                    .Where(strFilter)
                    .Count();

                recordsTotal = recCount;
                int recFilter = recCount;


                var v =
                     _context.LocationItemDetails

                            .Where(a => a.Status == "Active")
                            .Where(a => a.CreatedDate.Date >= startDate.Date && a.CreatedDate.Date <= endDate.Date)

                            .Select(a => new
                            {
                                Location = a.Equipment == "FE" ? _context.LocationFireExtinguishers.Where(b => b.Id == a.HeaderId).FirstOrDefault().Location :
                                               a.Equipment == "EL" ? _context.LocationEmergencyLights.Where(b => b.Id == a.HeaderId).FirstOrDefault().Location :
                                               a.Equipment == "FH" ? _context.LocationFireHydrants.Where(b => b.Id == a.HeaderId).FirstOrDefault().Location :
                                               _context.LocationInergenTanks.Where(b => b.Id == a.HeaderId).FirstOrDefault().Area,
                                AreaId = a.Equipment == "FE" ? _context.LocationFireExtinguishers.Where(b => b.Id == a.HeaderId).FirstOrDefault().AreaId :
                                               a.Equipment == "EL" ? _context.LocationEmergencyLights.Where(b => b.Id == a.HeaderId).FirstOrDefault().AreaId :
                                               a.Equipment == "FH" ? _context.LocationFireHydrants.Where(b => b.Id == a.HeaderId).FirstOrDefault().AreaId :
                                               _context.LocationInergenTanks.Where(b => b.Id == a.HeaderId).FirstOrDefault().AreaId,
                                a.Items.EquipmentType,
                                ItemName = a.Items.Code + " - " + a.Items.Name,
                                TransferredDate = a.CreatedDate,
                                SafeKeepDate = a.Items.DatePurchased,
                                a.CreatedDate
                                    ,
                                a.Status
                            })
                            .Where(a => a.AreaId == AreaId)
                            .Where(strFilter)
                            .Skip(skip).Take(pageSize);







                bool desc = false;
                if (sortColumnDirection == "desc")
                {
                    desc = true;
                }
                v = v.OrderBy(sortColumn + (desc ? " descending" : ""));





                var data = v;

                var jsonData = new { draw = draw, recordsFiltered = recFilter, recordsTotal = recordsTotal, data = data };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult getDataItemInventory(int AreaId)
        {
            string strFilter = "";
            try
            {



                DateTime? dt = new DateTime(1, 1, 0001);


                var v =
                       _context.Items
                       .GroupJoin(
                            _context.LocationItemDetails // B
                            .Where(a => a.Status == "Active"),
                            i => i.Id, //A key
                            p => p.ItemId,//B key
                            (i, g) =>
                                new
                                {
                                    i, //holds A data
                                    g  //holds B data
                                }
                        )
                        .SelectMany(
                            temp => temp.g.Take(1).DefaultIfEmpty(), //gets data and transfer to B
                            (A, B) =>
                                new
                                {
                                    A.i.Code,
                                    ItemName = A.i.Name,
                                    A.i.SerialNo,
                                    DatePurchased = A.i.DatePurchased == null ? dt : A.i.DatePurchased,

                                    A.i.ItemStatus,
                                    A.i.EquipmentType,
                                    Location = A.i.EquipmentType == "Fire Extinguisher" ? _context.LocationFireExtinguishers.Where(b => b.Id == B.HeaderId).FirstOrDefault().Location :
                                                A.i.EquipmentType == "Emergency Light" ? _context.LocationEmergencyLights.Where(b => b.Id == B.HeaderId).FirstOrDefault().Location :
                                                A.i.EquipmentType == "Fire Hydrant" ? _context.LocationFireHydrants.Where(b => b.Id == B.HeaderId).FirstOrDefault().Location :
                                                A.i.EquipmentType == "Inergen Tank" ? _context.LocationInergenTanks.Where(b => b.Id == B.HeaderId).FirstOrDefault().Area :
                                            "",
                                    Area = A.i.EquipmentType == "Fire Extinguisher" ? _context.LocationFireExtinguishers.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId == null ? 0 : _context.LocationFireExtinguishers.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId :
                                                A.i.EquipmentType == "Emergency Light" ? _context.LocationEmergencyLights.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId == null ? 0 : _context.LocationEmergencyLights.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId :
                                                A.i.EquipmentType == "Fire Hydrant" ? _context.LocationFireHydrants.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId == null ? 0 : _context.LocationFireHydrants.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId :
                                                A.i.EquipmentType == "Inergen Tank" ? _context.LocationInergenTanks.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId == null ? 0 : _context.LocationInergenTanks.Where(b => b.Id == B.HeaderId).FirstOrDefault().AreaId :
                                            0,

                                A.i.Warranty
                                            



                                }
                        );



                var rec = v.ToList();
                var model = new
                {

                    data = v.Where(a => a.Area == AreaId)
                };
                return Json(model);

            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        [BreadCrumb(Title = "Item History", Order = 2, IgnoreAjaxRequests = true)]
        public IActionResult ItemHistory()
        {
            ViewBag.Title = "Item History";
            ViewData["AreaId"] = new SelectList(_context.Areas, "ID", "Name");

            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "Reports",
                Url = string.Format(Url.Action("Index", "Reports")),
                Order = 1
            });
            return View();
        }
        [BreadCrumb(Title = "Item Inventory", Order = 2, IgnoreAjaxRequests = true)]
        public IActionResult ItemInventory()
        {
            ViewBag.Title = "Item Inventory";



            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "Reports",
                Url = string.Format(Url.Action("Index", "Reports")),
                Order = 1
            });


            var dept = _context.Areas.Where(a => a.Status == "Active")
                .Select(a => new
                {
                    a.ID,
                    Text = a.Name + " - " + a.Companies.Code
                });

            ViewData["AreaId"] = new SelectList(dept.OrderBy(a => a.Text), "ID", "Text");
            return View();




        }
        public IActionResult printReport(ReportViewModel rvm)
        {

            try
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = new HttpResponseMessage();
                byte[] bytes = null;
                string xstring = JsonConvert.SerializeObject(rvm);



                string urilive = "http://californium/ScreeningToolCPCApi/api/printreport?rvm=";
                string uridev = "http://sodium2/semapi/api/printreport?rvm=";
                string urilocal = "http://localhost:57903/api/printreport?rvm=";

                response = client.GetAsync(urilocal + xstring).Result;
                string byteToString = response.Content.ReadAsStringAsync().Result.Replace("\"", string.Empty);
                bytes = Convert.FromBase64String(byteToString);

                string rpttype = "";
                switch (rvm.rptType)
                {
                    case "PDF":
                        rpttype = "application/pdf";
                        break;
                    case "Excel":
                        rpttype = "application/vnd.ms-excel";
                        break;
                    default:
                        break;
                }


                return File(bytes, rpttype);
            }
            catch (Exception e)
            {

                throw;
            }

        }

    }
}