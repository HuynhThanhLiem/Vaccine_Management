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
    public class DeclarationController : Controller
    {
        private readonly ApplicationDbContext _context;
        [BindProperty]
        public HealthDeclarationViewModel hdec { get; set; }
        public DeclarationController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult OnSubmit(HealthDeclarationViewModel hl)
        {
            if (ModelState.IsValid)
            {
                //Save Citizen Information
                Citizen ctz = new Citizen();

                ctz.idCard = hl.idCard;
                ctz.fullName = hl.fullName;
                ctz.gender = hl.gender;
                ctz.dateOfBirth = hl.dateOfBirth;
                ctz.phoneNumber = hl.phoneNumber;
                ctz.email = hl.email;
                ctz.address = hl.address;
                ctz.healthInsurance = hl.healthInsurance;
                ctz.job = hl.job;
                ctz.company = hl.company;
                ctz.nation = hl.nation;
                ctz.nationality = hl.nationality;

                _context.Citizens.Add(ctz);
                _context.SaveChanges();

                //Save Health Declaration
                Health_Declaration decla = new Health_Declaration();

                var ctzFromDb = _context.Citizens.FirstOrDefault(u => u.idCard == hl.idCard);

                decla.citizenId = ctzFromDb.citizenId;
                decla.hasSymptom = hl.hasSymptom;
                decla.contactSymptom = hl.contactSymptom;
                decla.contactForeigner = hl.contactForeigner;
                decla.contactCovidPerson = hl.contactCovidPerson;
                decla.fromCovidPlace = hl.fromCovidPlace;
                decla.declaratedDate = DateTime.Now;

                _context.Health_Declarations.Add(decla);
                _context.SaveChanges();

                return View();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDeclaration(HealthDeclarationViewModel hl)
        {
            if (!ModelState.IsValid) return BadRequest("Enter required fields");
            
            //Save Citizen Information
            Citizen ctz = new Citizen();

            ctz.idCard = hl.idCard;
            ctz.fullName = hl.fullName;
            ctz.gender = hl.gender;
            ctz.dateOfBirth = hl.dateOfBirth;
            ctz.phoneNumber = hl.phoneNumber;
            ctz.email = hl.email;
            ctz.address = hl.address;
            ctz.healthInsurance = hl.healthInsurance;
            ctz.job = hl.job;
            ctz.company = hl.company;
            ctz.nation = hl.nation;
            ctz.nationality = hl.nationality;

            _context.Citizens.Add(ctz);
            _context.SaveChanges();

            //Save Health Declaration
            Health_Declaration decla = new Health_Declaration();

            var ctzFromDb = _context.Citizens.OrderByDescending(u => u.citizenId).FirstOrDefault();

            decla.citizenId = ctzFromDb.citizenId;
            decla.hasSymptom = hl.hasSymptom;
            decla.contactSymptom = hl.contactSymptom;
            decla.contactForeigner = hl.contactForeigner;
            decla.contactCovidPerson = hl.contactCovidPerson;
            decla.fromCovidPlace = hl.fromCovidPlace;
            decla.declaratedDate = DateTime.Now;

            _context.Health_Declarations.Add(decla);
            _context.SaveChanges();

            return this.Ok($"Form Data received!");
        }
    }
}
