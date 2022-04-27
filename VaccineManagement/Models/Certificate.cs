using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models
{
    public class Certificate
    {
        [Display(Name = "Ngày tiêm")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime vaccineedDate { get; set; }

        [Display(Name = "Mũi tiêm")]
        public int choiceInjections { get; set; }

        [Display(Name = "Batch Name")]
        [StringLength(50, ErrorMessage = "Tên lô Vaccine không được vượt quá 50 ký tự")]
        public string batchName { get; set; }

        [Display(Name = "Tỉnh/ thành phố")]
        [StringLength(50, ErrorMessage = "Tên tỉnh/ thành phố không được vượt quá 50 ký tự")]
        public string cityName { get; set; }
        [Display(Name = "Vaccine")]
        [StringLength(50, ErrorMessage = "Tên Vaccine không được vượt quá 50 ký tự")]
        public string name { get; set; }

        public int citizenId { get; set; }

        [Display(Name = "Họ và tên")]
        [StringLength(50, ErrorMessage = "Họ và tên không được vượt quá 50 ký tự")]
        public string fullName { get; set; }

        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateOfBirth { get; set; }

        [Display(Name = "CMND")]
        [StringLength(50, ErrorMessage = "Số CMND không được vượt quá 50 ký tự")]
        public string idCard { get; set; }

        [Display(Name = "SĐT")]
        [StringLength(50, ErrorMessage = "Số điện thoại không được vượt quá 50 ký tự")]
        public string phoneNumber { get; set; }

        [Display(Name = "Địa chỉ")]
        [StringLength(300, ErrorMessage = "Địa chỉ không được vượt quá 300 ký tự")]
        public string address { get; set; }

    }
}
