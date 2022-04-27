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
    public class BatchController : Controller
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Vaccine_Batch vbatch { get; set; }
        public BatchController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpSert(int? id)
        {
            ViewData["vaccineID"] = new SelectList(_context.Vaccines, "vaccineId", "name");
            vbatch = new Vaccine_Batch();
            if (id == null)
            {
                //create
                return View(vbatch);
            }
            //update
            vbatch = _context.Vaccine_Batches.FirstOrDefault(u => u.batchId == id);
            if (vbatch == null)
            {
                return NotFound();
            }
            return View(vbatch);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert()
        {
            if (ModelState.IsValid)
            {
                if (vbatch.batchId == 0)
                {
                    //create
                    _context.Vaccine_Batches.Add(vbatch);
                }
                else
                {
                    //update
                    _context.Vaccine_Batches.Update(vbatch);
                }
                //Console.WriteLine(Vaccine);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vbatch);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Console.WriteLine(Json(new { data = await _context.Vaccine_Batches.ToListAsync() }));
            return Json(new { data = await _context.Vaccine_Batches.Join(_context.Vaccines,
                b => b.vaccineId,
                v => v.vaccineId,
                (b,v) => new { 
                    b.batchId,
                    v.name,
                    b.importedDate,
                    b.quantity,
                    b.producedDate,
                    b.expiredDate,
                }).ToListAsync() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var vbatchFromDb = await _context.Vaccine_Batches.FirstOrDefaultAsync(u => u.batchId == id);
            if (vbatchFromDb == null)
            {
                return Json(new { success = false, message = "Delete Fail!" });
            }
            _context.Vaccine_Batches.Remove(vbatchFromDb);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successfully!" });
        }
        #endregion
    }
}
