using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VaccineManagement.Data;
using VaccineManagement.Models;
using VaccineManagement.Models.Entities;

namespace VaccineManagement.Controllers
{
    public class SearchRegistrationController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SearchRegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string GetRegistration(string idCard)
        {
            //Get data
            var query = _context.Vaccine_Registrations.Join(_context.Citizens,
                v => v.citizenId,
                c => c.citizenId,
                (v, c) => new
                {
                    v.registrationId,
                    v.choiceInjections,
                    v.registratedDate,
                    v.status,
                    c.citizenId,
                    c.fullName,
                    c.dateOfBirth,
                    c.gender,
                    c.phoneNumber,
                    c.idCard,
                }).Where(u => u.idCard == idCard).OrderBy(u => u.choiceInjections).ToArray();

            string result = "<table id=\"vaccineTable\" style=\"position: absolute; top: 50%; left: 5%; right: 5%; opacity: 1; display: block; padding-bottom: 100px\" " 
                            + "class=\"vaccine-table-search animate-box\" data-animate-effect=\"fadeInLeft\">\n"
                            + "<thead>\n"
                            + "<tr class=\"vaccine-table-color\" data-animate-effect=\"fadeInLeft\">\n"
                            + "<th>No</th>\n"
                            + "<th>Fullname</th>\n"
                            + "<th>Date of birth</th>\n"
                            + "<th>Gender</th>\n"
                            + "<th>Phone number</th>\n"
                            + "<th>Citizen identification code/Passport</th>\n"
                            + "<th>Choice Injection</th>\n"
                            + "<th>Registration Date</th>\n"
                            + "<th>Status</th>\n"
                            + "</tr>\n"
                            + "</thead>\n"
                            + "<tbody>\n";

            for (int i=0; i< query.Length; i++)
            {
                result += "<tr  class=\"vaccine-table-row\" data-animate-effect=\"fadeInLeft\">\n"
                            + "<td>" + (i+1) + "</td>\n"
                            + "<td>" + query[i].fullName + "</td>\n"
                            + "<td>" + query[i].dateOfBirth.ToShortDateString() + "</td>\n"
                            + "<td>" + query[i].gender + "</td>\n"
                            + "<td>" + query[i].phoneNumber + "</td>\n"
                            + "<td>" + query[i].idCard + "</td>\n"
                            + "<td>" + query[i].choiceInjections + "</td>\n"
                            + "<td>" + query[i].registratedDate.ToShortDateString() + "</td>\n"
                            + "<td>" + query[i].status +"</td>\n"
                            + "</tr>\n";
            }

            result += "</tbody>\n"
                    + "</table>\n";
            return result;
        }
    }
}
