using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models.Entities
{
    public class Medical_Staff
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int staffId { get; set; }

        [Required]
        [Display(Name = "Họ và tên")]
        [StringLength(50, ErrorMessage = "Họ và tên không được vượt quá 50 ký tự")]
        public string fullName { get; set; }

        [Required]
        [Display(Name = "SĐT")]
        [StringLength(50, ErrorMessage = "Số điện thoại không được vượt quá 50 ký tự")]
        public string phoneNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(50, ErrorMessage = "Email không được vượt quá 50 ký tự")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Nhiệm vụ")]
        [StringLength(50, ErrorMessage = "Nhiệm vụ không được vượt quá 50 ký tự")]
        public string assignment { get; set; }

        public List<Vaccination> Vaccinations { get; set; }
    }
}
