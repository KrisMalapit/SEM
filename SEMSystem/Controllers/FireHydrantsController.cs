﻿using System;
using System.Linq;
using System.Threading.Tasks;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Mvc;
using SEMSystem.Models;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using SEMSystem.Models.View_Model;

namespace SEMSystem.Controllers
{
    public class FireHydrantsController : Controller
    {
        private readonly SEMSystemContext _context;
        public FireHydrantsController(SEMSystemContext context)
        {
            _context = context;
        }
        [BreadCrumb(Title = "Index", Order = 1, IgnoreAjaxRequests = true)]
        // GET: Bicycles
        public async Task<IActionResult> Index()
        {
            this.SetCurrentBreadCrumbTitle("Fire Hydrants");
            return View();
        }
        [BreadCrumb(Title = "Create", Order = 2, IgnoreAjaxRequests = true)]
        // GET: FireHydrant/Create
        public IActionResult Create()
        {
            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "Fire Hydrant",
                Url = string.Format(Url.Action("Index")),
                Order = 1
            });
            ViewData["ID"] = 0;
            ViewData["Title"] = "Create";
            ViewData["AreaId"] = new SelectList(_context.Areas, "ID", "Name");
            ViewData["CreatedAt"] = DateTime.Now.Date.ToString("MM-dd-yyyy");
            return View();
        }
        [BreadCrumb(Title = "Edit", Order = 2, IgnoreAjaxRequests = true)]
        // GET: FireHydrant/Create
        public IActionResult Edit(int id)
        {
            var model = _context.FireHydrantHeaders.Find(id);

            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "Fire Hydrant",
                Url = string.Format(Url.Action("Index")),
                Order = 1
            });


            ViewData["ID"] = id;
            ViewData["AreaId"] = new SelectList(_context.Areas, "ID", "Name", model.AreaId);
            ViewData["Title"] = "Edit";
            ViewData["CreatedAt"] = model.CreatedAt.ToString("MM-dd-yyyy");

            return View("Create", model);
        }
        [HttpPost]
        public ActionResult getData()
        {
            string strFilter = "";
            try
            {



                var draw = Request.Form["draw"].FirstOrDefault();
                var start = Request.Form["start"].FirstOrDefault();
                var length = Request.Form["length"].FirstOrDefault();
                var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();
                var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();
                var searchValue = Request.Form["search[value]"].FirstOrDefault();
                int pageSize = length != null ? Convert.ToInt32(length) : 0;
                int skip = start != null ? Convert.ToInt32(start) : 0;
                int recordsTotal = 0;


                for (int i = 0; i < 2; i++)
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

                     _context.FireHydrantHeaders
                     .Select(a => new
                     {
                         a.CreatedAt,
                         CompanyName = a.Areas.Companies.Name,
                         AreaName = a.Areas.Name
                         ,
                         a.Status
                     })
                    .Where(a => a.Status == "Active")
                    .Where(strFilter)
                    .Count();

                recordsTotal = recCount;
                int recFilter = recCount;


                var v =

              _context.FireHydrantHeaders
               .Select(a => new
               {



                   a.CreatedAt,
                   CompanyName = a.Areas.Companies.Name,
                   AreaName = a.Areas.Name
                  ,
                   a.Id
                   ,
                   a.Status

               })
              .Where(strFilter)
              .Where(a => a.Status == "Active")
              .Skip(skip).Take(pageSize)
              ;

                //string strSql = v.ToSql();
                bool desc = false;
                if (sortColumnDirection == "desc")
                {
                    desc = true;
                }
                v = v.OrderBy(sortColumn + (desc ? " descending" : ""));





                var data = v;

                var jsonData = new { draw = draw, recordsFiltered = recFilter, recordsTotal, data };
                return Ok(jsonData);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
        public IActionResult getDataPerArea(int AreaId, DateTime dateTime)
        {
            string status = "";
            int headerid = 0;
            var v =

                _context.LocationFireHydrants
                .Where(a => a.Status == "Active")
                .Where(a => a.AreaId == AreaId)
                .Select(a => new {
                    a.Location,

                    a.Code,
                    a.Id,
                    CompanyName = a.Areas.Companies.Name
                });



            var detail = _context.FireHydrantDetails
                    .Where(a => a.FireHydrantHeaders.Status == "Active")
                    .Where(a => a.FireHydrantHeaders.AreaId == AreaId)
                    .Where(a => a.FireHydrantHeaders.CreatedAt == dateTime) //A
                                                                               //.Where(a => a.FireHydrantHeaderId == id) //A
                               .GroupJoin(
                                  _context.LocationFireHydrants // B
                                  .Where(a => a.Status == "Active"),
                                  i => i.LocationFireHydrantId, //A key
                                  p => p.Id,//B key
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

                                         Id = A.i.LocationFireHydrantId,

                                         A.i.GlassCabinet,
                                         A.i.Hanger,
                                         A.i.Hose15,
                                         A.i.Nozzle15,
                                         A.i.Hose25,
                                         A.i.Nozzle25,
                                         A.i.SpecialTools,

                                         A.i.Remarks,
                                         B.Location,
                                         B.Code,
                                         A.i.InspectedBy,
                                         A.i.ReviewedBy,
                                         A.i.NotedBy,

                                         CompanyName = B.Areas.Companies.Name,
                                         HeaderId = A.i.FireHydrantHeaderId
                                     }
                               );


            status = "success";
            //var x = detail.ToList();
            var model = new
            {
                status,

                datadetail = detail.ToList()
                ,
                data = v

            };
            return Json(model);
        }
        [HttpPost]
        public IActionResult SaveData(FireHydrantViewModel[] item)
        {
            int headerId = 0;
            string status = "";
            string message = "";
            try
            {
                var _header = _context.FireHydrantHeaders.Where(a => a.Status == "Active")
                    .Where(a => a.AreaId == item[0].AreaId)
                    .Where(a => a.CreatedAt == DateTime.Now.Date);

                if (_header.Count() == 0)
                {
                    FireHydrantHeader header = new FireHydrantHeader();
                    header.AreaId = item[0].AreaId;
                    header.CreatedAt = DateTime.Now.Date;
                    header.CreatedBy = User.Identity.GetUserName();
                    _context.Add(header);
                    _context.SaveChanges();
                    headerId = header.Id;

                    foreach (var detail in item)
                    {
                        var _detail = new FireHydrantDetail
                        {
                            LocationFireHydrantId = detail.LocationFireHydrantId,
                            GlassCabinet = detail.GlassCabinet == "true" ? 1 : 0,
                            Hanger = detail.Hanger == "true" ? 1 : 0,
                            Hose15 = detail.Hose15 == "true" ? 1 : 0,
                            Nozzle15 = detail.Nozzle15 == "true" ? 1 : 0,
                            Hose25 = detail.Hose25 == "true" ? 1 : 0,
                            Nozzle25 = detail.Nozzle25 == "true" ? 1 : 0,
                            SpecialTools = detail.SpecialTools == "true" ? 1 : 0,


                            InspectedBy = detail.InspectedBy,
                            ReviewedBy = detail.ReviewedBy,
                            NotedBy = detail.NotedBy,







                            CreatedAt = DateTime.Now.Date,
                            UpdatedAt = DateTime.Now.Date,
                            FireHydrantHeaderId = headerId,
                            Remarks = detail.Remarks


                        };

                        _context.Add(_detail);
                    }
                }
                else
                {
                    headerId = _header.FirstOrDefault().Id;

                    foreach (var detail in item)
                    {
                        var d = _context.FireHydrantDetails
                            .Where(a => a.FireHydrantHeaderId == headerId)
                            .Where(a => a.LocationFireHydrantId == detail.LocationFireHydrantId)
                            .FirstOrDefault();

                        if (d == null)
                        {

                            var _detail = new FireHydrantDetail
                            {
                                LocationFireHydrantId = detail.LocationFireHydrantId,
                           


                                GlassCabinet = detail.GlassCabinet == "true" ? 1 : 0,
                                Hanger = detail.Hanger == "true" ? 1 : 0,
                                Hose15 = detail.Hose15 == "true" ? 1 : 0,
                                Nozzle15 = detail.Nozzle15 == "true" ? 1 : 0,
                                Hose25 = detail.Hose25 == "true" ? 1 : 0,
                                Nozzle25 = detail.Nozzle25 == "true" ? 1 : 0,
                                SpecialTools = detail.SpecialTools == "true" ? 1 : 0,


                                InspectedBy = detail.InspectedBy,
                                ReviewedBy = detail.ReviewedBy,
                                NotedBy = detail.NotedBy,




                                CreatedAt = DateTime.Now.Date,
                                UpdatedAt = DateTime.Now,
                                FireHydrantHeaderId = headerId,
                                Remarks = detail.Remarks
                            };

                            _context.Add(_detail);


                        }
                        else
                        {
                                d.GlassCabinet = detail.GlassCabinet == "true" ? 1 : 0;
                                d.Hanger = detail.Hanger == "true" ? 1 : 0;
                                d.Hose15 = detail.Hose15 == "true" ? 1 : 0;
                            d.Nozzle15 = detail.Nozzle15 == "true" ? 1 : 0;
                            d.Hose25 = detail.Hose25 == "true" ? 1 : 0;
                            d.Nozzle25 = detail.Nozzle25 == "true" ? 1 : 0;
                            d.SpecialTools = detail.SpecialTools == "true" ? 1 : 0;


                            d.InspectedBy = detail.InspectedBy;
                            d.Remarks = detail.Remarks;
                            d.NotedBy = detail.NotedBy;






                            d.UpdatedAt = DateTime.Now;
                            d.UpdatedBy = User.Identity.GetUserName();
                            d.FireHydrantHeaderId = headerId;
                            d.ReviewedBy = detail.ReviewedBy;

                            _context.Update(d);
                        }
                        _context.SaveChanges();
                    }
                }





                _context.SaveChanges();
                status = "success";

            }
            catch (Exception ex)
            {

                status = "failed";
                message = ex.InnerException.Message;
            }





            var model = new
            {
                status
                ,
                message
                 ,
                ReferenceId = headerId
            };
            return Json(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string status = "";
            string message = "";
            try
            {


                var mddaf = _context.FireHydrantHeaders.Find(id);
                mddaf.Status = "Deleted_" + DateTime.Now.Ticks.ToString();
                _context.Update(mddaf);


                Log log = new Log();
                log.Descriptions = "Delete FireHydrantHeader Id : " + id;
                log.Action = "Delete";
                log.Status = "Success";
                log.UserId = User.Identity.GetUserName();
                log.CreatedDate = DateTime.Now;
                _context.Add(log);


                _context.SaveChanges();

                status = "success";


            }
            catch (Exception e)
            {
                status = "failed";
                message = e.Message;

            }


            var model = new { status, message };
            return Json(model);
        }
        [HttpPost]
        public ActionResult getDataDetails(int id)
        {
            string status = "";
            var v = _context.FireHydrantDetails.Where(a => a.FireHydrantHeaderId == id) //A
                    .GroupJoin(
                       _context.LocationFireHydrants // B
                       .Where(a => a.Status == "Active"),
                       i => i.LocationFireHydrantId, //A key
                       p => p.Id,//B key
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

                              Id = A.i.LocationFireHydrantId,
                              A.i.GlassCabinet,
                              A.i.Hanger,
                              A.i.Hose15,
                              A.i.Nozzle15,
                              A.i.Hose25,
                              A.i.Nozzle25,
                              A.i.SpecialTools,



                              A.i.Remarks,
                              B.Location,
                              B.Code,
                              A.i.InspectedBy,
                              A.i.ReviewedBy,
                              A.i.NotedBy,

                              CompanyName = B.Areas.Companies.Name
                          }
                    );

            status = "success";

            var model = new
            {
                status
                ,
                data = v

            };
            return Json(model);
        }
    }
}