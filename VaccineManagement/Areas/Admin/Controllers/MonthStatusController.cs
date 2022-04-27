using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineManagement.Data;

namespace VaccineManagement.Areas.Admin.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    public class MonthStatusController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MonthStatusController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public Array Index()
        {
            var query = _context.Vaccinations.Select(u => new
            {
                month = u.vaccineedDate.Month,
                year = u.vaccineedDate.Year,
                id = u.vaccinationId,
            }).ToArray();

            var result = query.GroupBy(a => new { a.month, a.year}).Select(a => new { Date = a.Key, Vaccineed = a.Count() }).ToArray();

            return result;
        }
    }
}
