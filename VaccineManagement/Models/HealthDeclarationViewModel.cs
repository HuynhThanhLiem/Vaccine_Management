using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models
{
    public class HealthDeclarationViewModel
    {
        [Required]
        [Display(Name = "CMND")]
        [StringLength(50, ErrorMessage = "Số CMND không được vượt quá 50 ký tự")]
        public string idCard { get; set; }

        [Required]
        [Display(Name = "Họ và tên")]
        [StringLength(50, ErrorMessage = "Họ và tên không được vượt quá 50 ký tự")]
        public string fullName { get; set; }

        [Required]
        [Display(Name = "Giới tính")]
        [StringLength(5, ErrorMessage = "Giới tính không được vượt quá 5 ký tự")]
        public string gender { get; set; }

        [Required]
        [Display(Name = "Ngày sinh")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime dateOfBirth { get; set; }

        [Required]
        [Display(Name = "SĐT")]
        [StringLength(50, ErrorMessage = "Số điện thoại không được vượt quá 50 ký tự")]
        public string phoneNumber { get; set; }

        [Required]
        [Display(Name = "Email")]
        [StringLength(50, ErrorMessage = "Email không được vượt quá 50 ký tự")]
        public string email { get; set; }

        [Required]
        [Display(Name = "Địa chỉ")]
        [StringLength(300, ErrorMessage = "Địa chỉ không được vượt quá 300 ký tự")]
        public string address { get; set; }

        [Required]
        [Display(Name = "Mã BHYT")]
        [StringLength(50, ErrorMessage = "Mã BHYT không được vượt quá 50 ký tự")]
        public string healthInsurance { get; set; }

        [Required]
        [Display(Name = "Nghề nghiệp")]
        [StringLength(50, ErrorMessage = "Nghề nghiệp không được vượt quá 50 ký tự")]
        public string job { get; set; }

        [Required]
        [Display(Name = "Đơn vị công tác")]
        [StringLength(50, ErrorMessage = "Đơn vị công tác không được vượt quá 50 ký tự")]
        public string company { get; set; }

        [Required]
        [Display(Name = "Dân tộc")]
        [StringLength(50, ErrorMessage = "Dân tộc không được vượt quá 50 ký tự")]
        public string nation { get; set; }

        [Required]
        [Display(Name = "Quốc tịch")]
        [StringLength(50, ErrorMessage = "Quốc tịch không được vượt quá 50 ký tự")]
        public string nationality { get; set; }

        [Required]
        [Display(Name = "Triệu chứng")]
        [StringLength(10, ErrorMessage = "Triệu chứng không được vượt quá 10 ký tự")]
        public string hasSymptom { get; set; }

        [Required]
        [Display(Name = "Tiếp xúc triệu chứng")]
        [StringLength(10, ErrorMessage = "Tiếp xúc triệu chứng không được vượt quá 10 ký tự")]
        public string contactSymptom { get; set; }

        [Required]
        [Display(Name = "Tiếp xúc nước ngoài")]
        [StringLength(10, ErrorMessage = "Tiếp xúc nước ngoài không được vượt quá 10 ký tự")]
        public string contactForeigner { get; set; }

        [Required]
        [Display(Name = "Tiếp xúc F0")]
        [StringLength(10, ErrorMessage = "Tiếp xúc F0 không được vượt quá 10 ký tự")]
        public string contactCovidPerson { get; set; }

        [Required]
        [Display(Name = "Đến từ vùng dịch")]
        [StringLength(10, ErrorMessage = "Đến từ vùng dịch không được vượt quá 10 ký tự")]
        public string fromCovidPlace { get; set; }

        [Required]
        [Display(Name = "Make Sure")]
        public bool makeSure { get; set; }
    }
}
