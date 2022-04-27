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
    public class VaccinesController : Controller
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public Vaccine vcine { get; set; }
        public VaccinesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult UpSert(int? id)
        {
            vcine = new Vaccine();
            if (id == null)
            {
                //create
                return View(vcine);
            }
            //update
            vcine = _context.Vaccines.FirstOrDefault(u => u.vaccineId == id);
            if (vcine == null)
            {
                return NotFound();
            }
            return View(vcine);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpSert()
        {
            if (ModelState.IsValid)
            {
                if (vcine.vaccineId == 0)
                {
                    //create
                    _context.Vaccines.Add(vcine);
                }
                else
                {
                    //update
                    _context.Vaccines.Update(vcine);
                }
                //Console.WriteLine(Vaccine);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vcine);
        }
        public void ExportToExcel()
        {
            var lst = _context.Vaccines.ToList();

            ExcelPackage.LicenseContext = LicenseContext.Commercial;

            ExcelPackage pck = new ExcelPackage();
            ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Report");

            ws.Cells["A1"].Value = "ID";
            ws.Cells["B1"].Value = "Name";
            ws.Cells["C1"].Value = "Origin";
            ws.Cells["D1"].Value = "Max Range";
            ws.Cells["E1"].Value = "Expired";
            ws.Cells["F1"].Value = "Doses";

            int rowStart = 2;
            foreach (var item in lst)
            {
                //ws.Row(rowStart).Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;

                ws.Cells[string.Format("A{0}", rowStart)].Value = item.vaccineId;
                ws.Cells[string.Format("B{0}", rowStart)].Value = item.name;
                ws.Cells[string.Format("C{0}", rowStart)].Value = item.origin;
                ws.Cells[string.Format("D{0}", rowStart)].Value = item.maxRange;
                ws.Cells[string.Format("E{0}", rowStart)].Value = item.expired;
                ws.Cells[string.Format("F{0}", rowStart)].Value = item.doses;
                rowStart++;
            }

            ws.Cells["A:AZ"].AutoFitColumns();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.Headers.Add("content-disposition", "attachment:filename=" + "ExcelReport.xlsx");
            Response.Body.WriteAsync(pck.GetAsByteArray());
            //HttpContext.Response.StatusCode = StatusCodes.Status200OK;
        }
        #region API Calls
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Console.WriteLine(Json(new { data = await _context.Vaccines.ToListAsync() }));
            return Json(new { data = await _context.Vaccines.ToListAsync() });
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var vaccineFromDb = await _context.Vaccines.FirstOrDefaultAsync(u => u.vaccineId == id);
            if (vaccineFromDb == null)
            {
                return Json(new { success = false, message = "Delete Fail!" });
            }
            _context.Vaccines.Remove(vaccineFromDb);
            await _context.SaveChangesAsync();
            return Json(new { success = true, message = "Delete Successfully!" });
        }
        #endregion
        
    }
}
