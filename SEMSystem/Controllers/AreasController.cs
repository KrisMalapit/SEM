using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DNTBreadCrumb.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SEMSystem.Models;
using SEMSystem.Models.View_Model;

namespace SEMSystem.Controllers
{
    public class AreasController : Controller
    {
        private readonly SEMSystemContext _context;

        public AreasController(SEMSystemContext context)
        {
            _context = context;
        }
        [BreadCrumb(Title = "Index", Order = 1, IgnoreAjaxRequests = true)]
        // GET: Areas
        public async Task<IActionResult> Index()
        {
            this.SetCurrentBreadCrumbTitle("Areas");
            var SEMSystemContext = _context.Areas.Include(d => d.Companies);

            return View();
        }
        public IActionResult getData()
        {
            string status = "";
            var v =

                _context.Areas.Where(a => a.Status != "Deleted").Select(a => new {


                    a.Code
                      ,
                    a.Name
                    ,
                    CompanyName = a.Companies.Name,
                    a.ID




                });
            status = "success";






            var model = new
            {
                status
                ,
                data = v
            };
            return Json(model);
        }
        // GET: Areas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Area = await _context.Areas
                .Include(d => d.Companies)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Area == null)
            {
                return NotFound();
            }

            return View(Area);
        }

        [BreadCrumb(Title = "Create", Order = 2, IgnoreAjaxRequests = true)]
        // GET: Areas/Create
        public IActionResult Create()
        {
            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "Area",
                Url = string.Format(Url.Action("Index", "Areas")),
                Order = 1
            });

            ViewData["CompanyId"] = new SelectList(_context.Companies, "ID", "Name");
            return View();
        }

        // POST: Areas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Code,Name,Status,CompanyId")] Area Area)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Area);
                await _context.SaveChangesAsync();


                Log log = new Log
                {
                    Descriptions = "Create Area - " + Area.ID,
                    Action = "Create",
                    Status = "success",
                    UserId = User.Identity.GetUserName()
                };
                _context.Add(log);

                _context.SaveChanges();



                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "ID", "Name", Area.CompanyId);
            return View(Area);
        }
        [BreadCrumb(Title = "Edit", Order = 2, IgnoreAjaxRequests = true)]
        // GET: Areas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "Area",
                Url = string.Format(Url.Action("Index", "Areas")),
                Order = 1
            });

            var Area = await _context.Areas.FindAsync(id);
            if (Area == null)
            {
                return NotFound();
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "ID", "Name", Area.CompanyId);
            return View(Area);
        }

        // POST: Areas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Code,Name,Status,CompanyId")] Area Area)
        {
            if (id != Area.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Area);
                    await _context.SaveChangesAsync();

                    Log log = new Log
                    {
                        Descriptions = "Update Area - " + Area.ID,
                        Action = "Edit",
                        Status = "success",
                        UserId = User.Identity.GetUserName()
                    };
                    _context.Add(log);

                    _context.SaveChanges();


                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AreaExists(Area.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompanyId"] = new SelectList(_context.Companies, "ID", "Name", Area.CompanyId);
            return View(Area);
        }

        [BreadCrumb(Title = "Delete", Order = 2, IgnoreAjaxRequests = true)]
        // GET: Areas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            this.AddBreadCrumb(new BreadCrumb
            {
                Title = "Area",
                Url = string.Format(Url.Action("Index", "Areas")),
                Order = 1
            });
            var Area = await _context.Areas
                .Include(d => d.Companies)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (Area == null)
            {
                return NotFound();
            }

            return View(Area);
        }

        // POST: Areas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var model = await _context.Areas.FindAsync(id);
            model.Status = "Deleted";
            _context.Update(model);
            await _context.SaveChangesAsync();


            Log log = new Log
            {
                Descriptions = "Delete Area - " + id,
                Action = "Delete",
                Status = "success",
                UserId = User.Identity.GetUserName()
            };
            _context.Add(log);
            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult SaveLocation(LocationViewModel locdetail)
        {
          

            string YearToDate = DateTime.Now.Year.ToString();

            string status = "";
            string message = "";
            string comp = User.Identity.GetCompanyAccess();

            try
            {
                    int dcnt = locdetail.location.Count();
                    for (int i = 0; i < dcnt; i++)
                    {
                        var loc = new LocationFireExtinguisher
                        {
                            Capacity = locdetail.capacity[i],
                            AreaId = locdetail.AreaId,
                            Code = locdetail.code[i],
                            Location = locdetail.location[i],
                            Status = "Active"
                        };

                        _context.Add(loc);
                      

                    }
                  
                    _context.SaveChanges();
                    status = "success";
            }
            catch (Exception e)
            {
                message = e.Message;
                status = "failed";

            }

            var model = new { status, message };
            return Json(model);

        }
        private bool AreaExists(int id)
        {
            return _context.Areas.Any(e => e.ID == id);
        }
    }
}
