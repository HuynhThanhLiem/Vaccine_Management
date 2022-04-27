using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
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
    public class GetVaccineedByAgeController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GetVaccineedByAgeController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public Array Index()
        {
            var query = _context.Vaccinations.Join(_context.Vaccine_Registrations,
                v => v.registrationId,
                r => r.registrationId,
                (v, r) => new
                {
                    r.registrationId,
                    r.citizenId,
                }).Join(_context.Citizens,
                    key => key.citizenId,
                    c => c.citizenId,
                    (key, c) => new
                    {
                        c.fullName,
                        c.dateOfBirth.Year,
                    }).ToList();
            var result = query.Distinct().ToArray();

            return result;
        }
    }
}
