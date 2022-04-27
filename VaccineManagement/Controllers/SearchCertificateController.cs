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
    public class SearchCertificateController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SearchCertificateController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public string GetCertificate(string idCard)
        {

            var query = _context.Citizens.Where(c => c.idCard == idCard).Select(c => c.citizenId).ToArray();

            int ID = query[0];

            #region result
            var result = _context.Vaccinations.Join(_context.Vaccine_Registrations,
                                    v => v.registrationId,
                                    r => r.registrationId,
                                    (v, r) => new
                                    {
                                        v.vaccineedDate,
                                        v.cityId,
                                        v.batchId,
                                        r.choiceInjections,
                                        r.citizenId,
                                    }).Join(_context.Cities,
                                            k => k.cityId,
                                            c => c.cityId,
                                            (k, c) => new
                                            {
                                                k.vaccineedDate,
                                                k.batchId,
                                                k.choiceInjections,
                                                k.citizenId,
                                                c.cityName,
                                            }).Join(_context.Vaccine_Batches,
                                                    l => l.batchId,
                                                    b => b.batchId,
                                                    (l, b) => new
                                                    {
                                                        l.vaccineedDate,
                                                        l.choiceInjections,
                                                        l.citizenId,
                                                        l.cityName,
                                                        b.batchName,
                                                        b.vaccineId,
                                                    }).Join(_context.Vaccines,
                                                        m => m.vaccineId,
                                                        v => v.vaccineId,
                                                        (m, v) => new
                                                        {
                                                            m.vaccineedDate,
                                                            m.choiceInjections,
                                                            m.citizenId,
                                                            m.batchName,
                                                            m.cityName,
                                                            v.name,
                                                        }).Join(_context.Citizens,
                                                                p => p.citizenId,
                                                                c => c.citizenId,
                                                                (p, c) => new
                                                                {
                                                                    p.vaccineedDate,
                                                                    p.choiceInjections,
                                                                    p.batchName,
                                                                    p.cityName,
                                                                    p.name,
                                                                    p.citizenId,
                                                                    c.fullName,
                                                                    c.dateOfBirth,
                                                                    c.idCard,
                                                                    c.phoneNumber,
                                                                    c.address,
                                                                }).Where(n => n.citizenId == ID).OrderBy(r => r.choiceInjections).ToArray();

            #endregion

            Citizen ctz = new Citizen();
            
            //Get Information
            for (int i=0; i<result.Length; i++)
            {
                ctz.fullName = result[i].fullName;
                ctz.dateOfBirth = result[i].dateOfBirth;
                ctz.idCard = result[i].idCard;
                ctz.phoneNumber = result[i].phoneNumber;
                ctz.address = result[i].address;
                break;
            }

            //Information
            string information = "<div id=\"fh5co-main\" data-animate-effect=\"fadeInLeft\">\n"
                + "<div class=\"fh5co-narrow-content-2 certificate animate-box\" style=\"opacity:1\" data-animate-effect=\"fadeInLeft\">\n"
                + "<div _ngcontent-xkl-c8=\"\" class=\"w-100 text-center\">\n"
                + "<p _ngcontent-xkl-c8=\"\" class=\"text-uppercase sfbold mb-1\"> SOCIALIST REPUBLIC OF VIETNAM </p>\n"
                + "<p _ngcontent-xkl-c8=\"\" class=\"sfbold\"> Independence-Freedom-Happiness </p>\n"
                + "</div>\n"
                + "<div _ngcontent-xkl-c8=\"\" class=\"w-100 mt-4 text-center mb-4\">\n"
                + "<h4 _ngcontent-xkl-c8=\"\" class=\"sfbold title-certificate\"> COVID-19 VACCINE CERTIFICATE </h4>\n"
                + "</div>\n"
                + "<div _ngcontent-xkl-c8=\"\" class=\"row\">\n"
                + "<div _ngcontent-xkl-c8=\"\" class=\"col-lg-4 col-md-6\">\n"
                + "<p _ngcontent-xkl-c8=\"\" class=\"mb-1 text-title\">\n"
                + "<i class=\"fas fa-user\" aria-hidden=\"true\"></i>\n"
                + "Fullname\n"
                + "</p>\n"
                + "<p _ngcontent-xkl-c8=\"\" class=\"sfbold text-dark\">" + ctz.fullName + "</p>\n"
                + "</div>\n"
                + "<div _ngcontent-xkl-c8=\"\" class=\"col-lg-4 col-md-6\">\n"
                + "<p _ngcontent-xkl-c8=\"\" class=\"mb-1 text-title\">\n"
                + "<i class=\"fas fa-birthday-cake\" aria-hidden=\"true\"></i>\n"
                + "Date of birth\n"
                + "</p>\n"
                + "<p _ngcontent-xkl-c8=\"\" class=\"sfbold text-dark\">" + ctz.dateOfBirth.ToShortDateString() + "</p>\n"
                + "</div>\n"
                + "<div _ngcontent-xkl-c8=\"\" class=\"col-lg-4 col-md-6\">\n"
                + "<p _ngcontent-xkl-c8=\"\" class=\"mb-1 text-title\">\n"
                + "<i class=\"fas fa-address-card\" aria-hidden=\"true\"></i>\n"
                + "Identification/Citizen identification code/ Passport\n"
                + "</p>\n"
                + "<p _ngcontent-xkl-c8=\"\" class=\"sfbold text-dark\">" + ctz.idCard + "</p>\n"
                + "</div>\n"
                + "<div _ngcontent-xkl-c8=\"\" class=\"col-lg-4 col-md-6\">\n"
                + "<p _ngcontent-xkl-c8=\"\" class=\"mb-1 text-title\">\n"
                + "<i class=\"fas fa-mobile-alt\"></i>\n"
                + "Phone Number\n"
                + "</p>\n"
                + "<p _ngcontent-xkl-c8=\"\" class=\"sfbold text-dark\">" + ctz.phoneNumber + "</p>\n"
                + "</div>\n"
                + "<div _ngcontent-xkl-c8=\"\" class=\"col-lg-4 col-md-6\">\n"
                + "<p _ngcontent-xkl-c8=\"\" class=\"mb-1 text-title\">\n"
                + "<i class=\"fas fa-map-marked\"></i>\n"
                + "Address\n"
                + "</p>\n"
                + "<p _ngcontent-xkl-c8=\"\" class=\"sfbold text-dark\">" + ctz.address + "</p>\n"
                + "</div>\n";
            //Table Information
            string table = "<table class=\"vaccine-table-reg table-hover vaccine-table\" data-animate-effect=\"fadeInLeft\">\n"
                + "<thead>\n"
                + "<tr class=\"vaccine-table-color\" data-animate-effect=\"fadeInLeft\">\n"
                + "<th>Vacccine ID</th>\n"
                + "<th>VaccineedDate</th>\n"
                + "<th>Vaccination</th>\n"
                + "<th>Vaccine Batch</th>\n"
                + "<th>The Covid-19 vaccine locations</th>\n"
                + "</tr>\n"
                + "</thead>\n"
                + "<tbody>\n";
            
            for (int i = 0; i < result.Length; i++)
            {
                table += "<tr class=\"vaccine-table-row\">\n"
                + "<td scope = \"row\">" + result[i].choiceInjections + "</td>\n"
                + "<td> " + result[i].vaccineedDate.ToShortDateString() + " </td>\n"
                + "<td> " + result[i].name + "</td>\n"
                + "<td> " + result[i].batchName + " </td>\n"
                + "<td> " + result[i].cityName + " </td>\n"
                + "</tr>\n";
            }

            table += "</tbody>\n"
                + "</table>\n"
                + "</div>\n";

            string pictureQr = "<div class=\"certificate-bg animate-box\" style=\"opacity:1\" data-animate-effect=\"fadeInLeft\">\n"
                + "<div class=\"container\">\n"
                + "<div class=\"row\">\n"
                + "<div class=\"col-sm-3 img-certificate\">\n"
                + "<div class=\"qrcode\">\n"
                + "<img src=\"\" />"
                + "</div>\n"
                + "</div>\n"
                + "<div class=\"col-sm-9\" style=\"line-height: 4rem;\">\n"
                + "<div class=\"row\">\n"
                + "<div class=\"col-8 col-sm-6 title-certificate-text\">\n"
                + "HAVE HAD '" + result.Length + "' VACCINATIONS\n"
                + "</div>\n"
                + "<div class=\"col-4 col-sm-6\">\n"
                + "</div>\n"
                + "</div>\n"
                + "<div class=\"row\">\n"
                + "<div class=\"col-8 col-sm-6 color-blue-light\">\n"
                + "<div class=\"vertical-line\"></div>\n"
                + "<i class=\"fas fa-user\" aria-hidden=\"true\"></i>\n"
                + "Fullname:\n"
                + "</div>\n"
                + "<div class=\"col-4 col-sm-6 color-white\">\n"
                + ctz.fullName + "\n"
                + "</div>\n"
                + "</div>\n"
                + "<div class=\"row\">\n"
                + "<div class=\"col-8 col-sm-6 color-blue-light\">\n"
                + "<div class=\"vertical-line\"></div>\n"
                + "<i class=\"fas fa-birthday-cake\" aria-hidden=\"true\"></i>\n"
                + "Date of birth:\n"
                + "</div>\n"
                + "<div class=\"col-4 col-sm-6 color-white\">\n"
                + ctz.dateOfBirth +"\n"
                + "</div>\n"
                + "</div>\n"
                + "<div class=\"row\">\n"
                + "<div class=\"col-8 col-sm-6 color-blue-light\">\n"
                + "<div class=\"vertical-line\"></div>\n"
                + "<i class=\"fas fa-address-card\" aria-hidden=\"true\"></i>\n"
                + "Identification/Citizen identification code/ Passport:\n"
                + "</div>\n"
                + "<div class=\"col-4 col-sm-6 color-white\">\n"
                + ctz.idCard + "\n"
                + "</div>\n"
                + "</div>\n"
                + "</div>\n"
                + "</div>\n"
                + "</div>\n"
                + "</div>\n"
                + "</div>\n"
                + "</div>\n";

            string kq = information + table + pictureQr;
            return kq;
        }
    }
}
