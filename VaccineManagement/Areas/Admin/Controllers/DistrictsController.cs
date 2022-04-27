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
    public class DistrictsController : Controller
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public District dtrict { get; set; }
        public DistrictsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpSert(int? id)
        {
            ViewData["cityId"] = new SelectList(_context.Cities, "cityId", "cityName");
            dtrict = new District();
            if (id == null)
            {
                //create
                return View(dtrict);
            }
            //update
            dtrict = _context.Districts.FirstOrDefault(u => u.districtId == id);
            if (dtrict == null)
            {
                return NotFound();
            }
            return View(dtrict);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert()
        {
            if (ModelState.IsValid)
            {
                if (dtrict.districtId == 0)
                {
                    //create
                    _context.Districts.Add(dtrict);
                }
                else
                {
                    //update
                    _context.Districts.Update(dtrict);
                }
                //Console.WriteLine(Vaccine);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dtrict);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Console.WriteLine(Json(new { data = await _context.Districts.ToListAsync() }));
            return Json(new { data = await _context.Districts.Join(_context.Cities,
                d => d.cityId,
                c => c.cityId,
                (d, c) => new {
                    d.districtId,
                    c.cityName,
                    d.districtName,
                }).ToListAsync()
            });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var districtFromDb = await _context.Districts.FirstOrDefaultAsync(u => u.districtId == id);
            if (districtFromDb == null)
            {
                return Json(new { success = false, message = "Delete Fail!" });
            }
            _context.Districts.Remove(districtFromDb);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successfully!" });
        }
        #endregion

    }
}
