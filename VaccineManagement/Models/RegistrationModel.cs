using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models
{
    public class RegistrationModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 8)]
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        public bool AcceptUserAgreement { get; set; }

        public string RegistrationInvalid { get; set; }
    }
}
