using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    public class CitiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public City ct { get; set; }
        public CitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpSert(int? id)
        {
            ct = new City();
            if (id == null)
            {
                //create
                return View(ct);
            }
            //update
            ct = _context.Cities.FirstOrDefault(u => u.cityId == id);
            if (ct == null)
            {
                return NotFound();
            }
            return View(ct);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert()
        {
            if (ModelState.IsValid)
            {
                if (ct.cityId == 0)
                {
                    //create
                    _context.Cities.Add(ct);
                }
                else
                {
                    //update
                    _context.Cities.Update(ct);
                }
                //Console.WriteLine(Vaccine);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ct);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Console.WriteLine(Json(new { data = await _context.Cities.ToListAsync() }));
            return Json(new { data = await _context.Cities.ToListAsync() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var cityFromDb = await _context.Cities.FirstOrDefaultAsync(u => u.cityId == id);
            if (cityFromDb == null)
            {
                return Json(new { success = false, message = "Delete Fail!" });
            }
            _context.Cities.Remove(cityFromDb);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successfully!" });
        }
        #endregion

    }
}
