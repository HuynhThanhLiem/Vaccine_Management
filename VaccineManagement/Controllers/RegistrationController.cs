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
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public RegistrationViewModel regis { get; set; }
        public RegistrationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRegistration(RegistrationViewModel reg)
        {
            if (!ModelState.IsValid) return BadRequest("Enter required fields");
            //Save Citizen Information
            Citizen ctz = new Citizen();

            ctz.idCard = reg.idCard;
            ctz.fullName = reg.fullName;
            ctz.gender = reg.gender;
            ctz.dateOfBirth = reg.dateOfBirth;
            ctz.phoneNumber = reg.phoneNumber;
            ctz.email = reg.email;
            ctz.address = reg.address;
            ctz.healthInsurance = reg.healthInsurance;
            ctz.job = reg.job;
            ctz.company = reg.company;
            ctz.nation = reg.nation;
            ctz.nationality = reg.nationality;

            _context.Citizens.Add(ctz);
            _context.SaveChanges();

            //Save Anamnesis
            Anamnesis ana = new Anamnesis();

            ana.anaphylaxis = reg.anaphylaxis;
            ana.lowImmunity = reg.lowImmunity;
            ana.acuteIllness = reg.acuteIllness;
            ana.allergy = reg.allergy;
            ana.older = reg.older;
            ana.pregnancy = reg.pregnancy;
            ana.bloodDisorder = reg.bloodDisorder;
            ana.useInhibition = reg.useInhibition;
            ana.developChronic = reg.developChronic;
            ana.curedChronic = reg.curedChronic;
            ana.vaccineedHalfMonth = reg.vaccineedHalfMonth;
            ana.covidSixMonths = reg.covidSixMonths;

            _context.Anamneses.Add(ana);
            _context.SaveChanges();

            //Save Vaccine Registration
            Vaccine_Registration vcreg = new Vaccine_Registration();

            var ctzFromDb = _context.Citizens.OrderByDescending(u=> u.citizenId).FirstOrDefault();
            var anaFromDb = _context.Anamneses.OrderByDescending(u => u.anamnesisId).FirstOrDefault();

            vcreg.citizenId = ctzFromDb.citizenId;
            vcreg.anamnesisId = anaFromDb.anamnesisId;
            vcreg.agreement = "Yes";
            vcreg.choiceInjections = reg.choiceInjections;
            vcreg.registratedDate = DateTime.Now;
            vcreg.status = "Wait";

            _context.Vaccine_Registrations.Add(vcreg);
            _context.SaveChanges();
            return this.Ok($"Form Data received!");
        }
    }
}
