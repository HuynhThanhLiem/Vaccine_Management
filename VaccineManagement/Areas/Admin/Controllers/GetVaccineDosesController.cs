using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineManagement.Data;

namespace VaccineManagement.Areas.Admin.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    public class GetVaccineDosesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GetVaccineDosesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public Array Index()
        {
            var lst = new ArrayList();

            lst.Add(new object[] {"Vaccine", "quantily"});

            var query = _context.Vaccine_Batches.Join(_context.Vaccines,
                b => b.vaccineId,
                v => v.vaccineId,
                (b, v) => new
                {
                    v.name,
                    b.quantity,
                }).ToArray();

            var result = query.GroupBy(a => a.name).Select(a => new { Name = a.Key, Quantity = a.Sum(b => b.quantity) }).OrderByDescending(a => a.Quantity).ToArray();

            return result;
        }
    }
}
