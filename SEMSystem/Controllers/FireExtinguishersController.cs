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
    public class FireExtinguishersController : Controller
    {
        private readonly SEMSystemContext _context;
        public FireExtinguishersController(SEMSystemContext context)
        {
            _context = context;
        }
        [BreadCrumb(Title = "Index", Order = 1, IgnoreAjaxRequests = true)]
        // GET: Bicycles
        public async Task<IActionResult> Index()
        {
            this.SetCurrentBreadCrumbTitle("Fire Extinguishers");
            return View();
        }
        [BreadCrumb(Title = "Create", Order = 2, IgnoreAjaxRequests = true)]
        // GET: FireExtinguisher/Create
        public IActionResult Create()
        {
            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "Fire Extinguisher",
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
        // GET: FireExtinguisher/Create
        public IActionResult Edit(int id)
        {
            var model = _context.FireExtinguisherHeaders.Find(id);

            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "Fire Extinguisher",
                Url = string.Format(Url.Action("Index")),
                Order = 1
            });


            ViewData["ID"] = id;
            ViewData["AreaId"] = new SelectList(_context.Areas, "ID", "Name",model.AreaId);
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

                     _context.FireExtinguisherHeaders
                     .Select(a => new
                     {
                         a.CreatedAt,
                         CompanyName = a.Areas.Companies.Name,
                         AreaName = a.Areas.Name
                         ,a.Status
                     })
                    .Where(a => a.Status == "Active")
                    .Where(strFilter)
                    .Count();

                recordsTotal = recCount;
                int recFilter = recCount;


                var v =

              _context.FireExtinguisherHeaders
               .Select(a => new
               {



                   a.CreatedAt,
                   CompanyName = a.Areas.Companies.Name,
                   AreaName = a.Areas.Name
                  ,
                   a.Id
                   ,a.Status

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

                var jsonData = new { draw = draw, recordsFiltered = recFilter, recordsTotal,  data };
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

                _context.LocationFireExtinguishers
                .Where(a => a.Status == "Active")
                .Where(a=>a.AreaId == AreaId)
                .Select(a => new {
                    a.Location,
                    a.Type,
                    a.Capacity,
                    a.Code,
                    a.Id,
                    CompanyName = a.Areas.Companies.Name
                });
         
            status = "success";


           


            var detail = _context.FireExtinguisherDetails
                    .Where(a => a.FireExtinguisherHeaders.Status == "Active")
                    .Where(a => a.FireExtinguisherHeaders.AreaId == AreaId)
                    .Where(a => a.FireExtinguisherHeaders.CreatedAt == dateTime) //A
                    .GroupJoin(
                       _context.LocationFireExtinguishers // B
                       .Where(a => a.Status == "Active"),
                       i => i.LocationFireExtinguisherId, //A key
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

                              Id = A.i.LocationFireExtinguisherId,
                              A.i.Cylinder,
                              A.i.Lever,
                              A.i.Gauge,
                              A.i.SafetySeal,
                              A.i.Hose,
                              A.i.Remarks,
                              B.Location,
                              B.Code,
                              B.Type,
                              B.Capacity,
                              A.i.InspectedBy,
                              A.i.ReviewedBy,
                              A.i.NotedBy,
                              CompanyName = B.Areas.Companies.Name,
                              HeaderId = A.i.FireExtinguisherHeaderId
                          }
                    );


           

            var model = new
            {
                status
                ,
                 
                datadetail = detail

                , data = v
            
            };
            return Json(model);
        }
        [HttpPost]
        public IActionResult SaveData(FireExtinguisherViewModel[] item)
        {
            int headerId = 0;
            string status = "";
            string message = "";
            try
            {
                var _header = _context.FireExtinguisherHeaders
                    .Where(a => a.Status == "Active")
                    .Where(a => a.AreaId == item[0].AreaId)
                    .Where(a => a.CreatedAt == DateTime.Now.Date);

                if (_header.Count() == 0)
                {

                    FireExtinguisherHeader header = new FireExtinguisherHeader
                    {
                        AreaId = item[0].AreaId,
                        CreatedAt = DateTime.Now.Date,
                        CreatedBy = User.Identity.GetUserName()
                    };

                    _context.Add(header);
                    _context.SaveChanges();
                    headerId = header.Id;

                    foreach (var detail in item)
                    {
                        var _detail = new FireExtinguisherDetail
                        {
                            LocationFireExtinguisherId = detail.LocationFireExtinguisherId,
                            Cylinder = detail.Cylinder == "true" ? 1 : 0,
                            Lever = detail.Lever == "true" ? 1 : 0,
                            Gauge = detail.Gauge == "true" ? 1 : 0,
                            SafetySeal = detail.SafetySeal == "true" ? 1 : 0,
                            Hose = detail.Hose == "true" ? 1 : 0,
                            CreatedAt = DateTime.Now.Date,
                            UpdatedAt = DateTime.Now.Date,
                            FireExtinguisherHeaderId = headerId,
                            Remarks = detail.Remarks,
                            InspectedBy = detail.InspectedBy,
                            ReviewedBy = detail.ReviewedBy,
                            NotedBy = detail.NotedBy


                        };

                        _context.Add(_detail);
                    }
                }
                else
                {
                    headerId = _header.FirstOrDefault().Id;

                    foreach (var detail in item)
                    {
                        var d = _context.FireExtinguisherDetails
                            .Where(a => a.FireExtinguisherHeaderId == headerId)
                            .Where(a => a.LocationFireExtinguisherId == detail.LocationFireExtinguisherId)
                            .FirstOrDefault();

                        if (d == null)
                        {

                            var _detail = new FireExtinguisherDetail
                            {
                                LocationFireExtinguisherId = detail.LocationFireExtinguisherId,
                                Cylinder = detail.Cylinder == "true" ? 1 : 0,
                                Lever = detail.Lever == "true" ? 1 : 0,
                                Gauge = detail.Gauge == "true" ? 1 : 0,
                                SafetySeal = detail.SafetySeal == "true" ? 1 : 0,
                                Hose = detail.Hose == "true" ? 1 : 0,
                                CreatedAt = DateTime.Now.Date,
                                UpdatedAt = DateTime.Now,
                                FireExtinguisherHeaderId = headerId,
                                Remarks = detail.Remarks,
                                InspectedBy = detail.InspectedBy,
                                ReviewedBy = detail.ReviewedBy,
                                NotedBy = detail.NotedBy
                            };

                            _context.Add(_detail);


                        }
                        else
                        {
                            d.Cylinder = detail.Cylinder == "true" ? 1 : 0;
                            d.Lever = detail.Lever == "true" ? 1 : 0;
                            d.Gauge = detail.Gauge == "true" ? 1 : 0;
                            d.SafetySeal = detail.SafetySeal == "true" ? 1 : 0;
                            d.Hose = detail.Hose == "true" ? 1 : 0;
                            d.UpdatedAt = DateTime.Now;
                            d.UpdatedBy = User.Identity.GetUserName();
                            d.FireExtinguisherHeaderId = headerId;
                            d.Remarks = detail.Remarks;
                            d.InspectedBy = detail.InspectedBy;
                            d.ReviewedBy = detail.ReviewedBy;
                            d.NotedBy = detail.NotedBy;
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
                ,message
                ,ReferenceId= headerId
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


                var mddaf = _context.FireExtinguisherHeaders.Find(id);
                mddaf.Status = "Deleted_" + DateTime.Now.Ticks.ToString();
                _context.Update(mddaf);


                Log log = new Log();
                log.Descriptions = "Delete FireExtinguisherHeader Id : " + id;
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
            var v = _context.FireExtinguisherDetails.Where(a => a.FireExtinguisherHeaderId == id) //A
                    .GroupJoin(
                       _context.LocationFireExtinguishers // B
                       .Where(a => a.Status == "Active"),
                       i => i.LocationFireExtinguisherId, //A key
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
                              
                              Id = A.i.LocationFireExtinguisherId,
                              A.i.Cylinder,
                              A.i.Lever,
                              A.i.Gauge,
                              A.i.SafetySeal,
                              A.i.Hose,
                              A.i.Remarks,
                              B.Location,
                              B.Code,
                              B.Type,
                              B.Capacity,
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