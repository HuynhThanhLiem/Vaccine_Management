using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineManagement.Data;
using VaccineManagement.Models.Entities;

namespace VaccineMG.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager,Admin")]
    public class WardsController : Controller
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Ward wd { get; set; }
        public WardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpSert(int? id)
        {
            ViewData["districtId"] = new SelectList(_context.Districts, "districtId", "districtName");
            wd = new Ward();
            if (id == null)
            {
                //create
                return View(wd);
            }
            //update
            wd = _context.Wards.FirstOrDefault(u => u.wardId == id);
            if (wd == null)
            {
                return NotFound();
            }
            return View(wd);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert()
        {
            if (ModelState.IsValid)
            {
                if (wd.wardId == 0)
                {
                    //create
                    _context.Wards.Add(wd);
                }
                else
                {
                    //update
                    _context.Wards.Update(wd);
                }
                //Console.WriteLine(Vaccine);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(wd);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Console.WriteLine(Json(new { data = await _context.Wards }));
            return Json(new { data = await _context.Wards.Join(_context.Districts,
                w => w.districtId,
                d => d.districtId,
                (w, d) => new {
                    w.wardId,
                    d.districtName,
                    w.wardName,
                }).ToListAsync()
            });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var wardFromDb = await _context.Wards.FirstOrDefaultAsync(u => u.wardId == id);
            if (wardFromDb == null)
            {
                return Json(new { success = false, message = "Delete Fail!" });
            }
            _context.Wards.Remove(wardFromDb);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successfully!" });
        }
        #endregion

    }
}
