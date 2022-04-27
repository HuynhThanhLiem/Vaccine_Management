using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;
using VaccineManagement.Data;
using VaccineManagement.Models.Entities;
using Excel = Microsoft.Office.Interop.Excel;

namespace VaccineManagement.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Manager,Admin")]
    public class VaccinationController : Controller
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Vaccination vcnation { get; set; }
        public VaccinationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Console.WriteLine(Json(new { data = await _context.Vaccines.ToListAsync() }));
            return Json(new { data = await _context.Vaccinations.ToListAsync() });
        }
        //[HttpDelete]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    var vaccineFromDb = await _context.Vaccines.FirstOrDefaultAsync(u => u.vaccineId == id);
        //    if (vaccineFromDb == null)
        //    {
        //        return Json(new { success = false, message = "Delete Fail!" });
        //    }
        //    _context.Vaccines.Remove(vaccineFromDb);
        //    await _context.SaveChangesAsync();
        //    return Json(new { success = true, message = "Delete Successfully!" });
        //}
        #endregion
    }
}
