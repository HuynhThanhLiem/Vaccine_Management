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
    public class AnamnesisController : Controller
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Anamnesis ana { get; set; }
        public AnamnesisController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpSert(int? id)
        {
            ana = new Anamnesis();
            if (id == null)
            {
                //create
                return View(ana);
            }
            //update
            ana = _context.Anamneses.FirstOrDefault(u => u.anamnesisId == id);
            if (ana == null)
            {
                return NotFound();
            }
            return View(ana);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert()
        {
            if (ModelState.IsValid)
            {
                if (ana.anamnesisId == 0)
                {
                    //create
                    _context.Anamneses.Add(ana);
                }
                else
                {
                    //update
                    _context.Anamneses.Update(ana);
                }
                //Console.WriteLine(Vaccine);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ana);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Console.WriteLine(Json(new { data = await _context.Anamneses.ToListAsync() }));
            return Json(new { data = await _context.Anamneses.ToListAsync() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var anaFromDb = await _context.Anamneses.FirstOrDefaultAsync(u => u.anamnesisId == id);
            if (anaFromDb == null)
            {
                return Json(new { success = false, message = "Delete Fail!" });
            }
            _context.Anamneses.Remove(anaFromDb);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successfully!" });
        }
        #endregion

    }
}
