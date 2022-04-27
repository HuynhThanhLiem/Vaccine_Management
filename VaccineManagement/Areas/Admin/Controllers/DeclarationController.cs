using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineManagement.Data;
using VaccineManagement.Models.Entities;

namespace VaccineManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager,Admin")]
    public class DeclarationController : Controller
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Health_Declaration declar { get; set; }
        public DeclarationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpSert(int? id)
        {
            declar = new Health_Declaration();
            if (id == null)
            {
                //create
                return View(declar);
            }
            //update
            declar = _context.Health_Declarations.FirstOrDefault(u => u.healthDeclarId == id);
            if (declar == null)
            {
                return NotFound();
            }
            return View(declar);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert()
        {
            if (ModelState.IsValid)
            {
                if (declar.healthDeclarId == 0)
                {
                    //create
                    _context.Health_Declarations.Add(declar);
                }
                else
                {
                    //update
                    _context.Health_Declarations.Update(declar);
                }
                //Console.WriteLine(Vaccine);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(declar);
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            Console.WriteLine(Json(new { data = await _context.Health_Declarations.ToListAsync() }));
            return Json(new { data = await _context.Health_Declarations.ToListAsync() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var declarFromDb = await _context.Health_Declarations.FirstOrDefaultAsync(u => u.healthDeclarId == id);
            if (declarFromDb == null)
            {
                return Json(new { success = false, message = "Delete Fail!" });
            }
            _context.Health_Declarations.Remove(declarFromDb);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successfully!" });
        }
        #endregion

    }
}
