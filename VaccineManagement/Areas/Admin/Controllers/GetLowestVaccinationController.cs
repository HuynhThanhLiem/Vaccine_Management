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
    public class GetLowestVaccinationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GetLowestVaccinationController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var highest2 = _context.Vaccinations.Join(_context.Cities,
                                                      v => v.cityId,
                                                      c => c.cityId,
                                                      (v, c) => new { c.cityName, v.vaccinationId }).ToArray();
            var result = highest2.GroupBy(a => a.cityName).Select(a => new { name = a.Key, vaccined = a.Count() }).OrderBy(a => a.vaccined).ToArray().Take(5);
            return Ok(result);
        }
    }
}
