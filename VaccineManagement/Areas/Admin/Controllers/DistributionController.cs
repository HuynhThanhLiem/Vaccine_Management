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
    public class DistributionController : Controller
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Batch_City distribution { get; set; }
        public DistributionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpSert(int? batchId, int? cityId)
        {
            ViewData["batchId"] = new SelectList(_context.Vaccine_Batches, "batchId","batchId");

            ViewData["cityId"] = new SelectList(_context.Cities, "cityId", "cityName");

            distribution = new Batch_City();
            if (batchId == null && cityId == null)
            {
                //create
                return View(distribution);
            }
            //update
            distribution = _context.Batch_Cities.FirstOrDefault(u => u.batchId == batchId && u.cityId == cityId);
            if (distribution == null)
            {
                return NotFound();
            }
            return View(distribution);
        }
        //Chua fix xong
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert()
        {

            if (ModelState.IsValid)
            {
                if (distribution.batchId == 0)
                {
                    //create
                    _context.Batch_Cities.Add(distribution);
                }
                else
                {
                    //update
                    _context.Batch_Cities.Update(distribution);
                }

                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distribution);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Console.WriteLine(Json(new { data = await _context.Batch_Cities.ToListAsync() }));
            return Json(new
            {
                data = await _context.Batch_Cities.Join(_context.Cities,
                dis => dis.cityId,
                c => c.cityId,
                (dis, c) => new {
                    dis.batchId,
                    dis.cityId,
                    dis.quantityVaccine,
                    dis.shippedDate,
                    c.cityName,
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
