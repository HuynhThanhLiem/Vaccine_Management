using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models
{
    public class RegistrationViewModel
    {
        [Required]
        [Display(Name = "Mũi tiêm")]
        public int choiceInjections { get; set; }

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
        [Display(Name = "Địa chỉ")]
        [StringLength(300, ErrorMessage = "Địa chỉ không được vượt quá 300 ký tự")]
        public string address { get; set; }

        [Required]
        [Display(Name = "Sốc phản vệ")]
        [StringLength(10, ErrorMessage = "Sốc phản vệ không được vượt quá 10 ký tự")]
        public string anaphylaxis { get; set; }

        [Required]
        [Display(Name = "Khả năng miễn dịch thấp")]
        [StringLength(10, ErrorMessage = "Khả năng miễn dịch thấp không được vượt quá 10 ký tự")]
        public string lowImmunity { get; set; }

        [Required]
        [Display(Name = "Bệnh cấp tính")]
        [StringLength(10, ErrorMessage = "Bệnh cấp tính không được vượt quá 10 ký tự")]
        public string acuteIllness { get; set; }

        [Required]
        [Display(Name = "Dị ứng")]
        [StringLength(10, ErrorMessage = "Dị ứng không được vượt quá 10 ký tự")]
        public string allergy { get; set; }

        [Required]
        [Display(Name = "Trên 65 tuổi")]
        [StringLength(10, ErrorMessage = "Trên 65 tuổi không được vượt quá 10 ký tự")]
        public string older { get; set; }

        [Required]
        [Display(Name = "Đang mang thai")]
        [StringLength(10, ErrorMessage = "Đang mang thai không được vượt quá 10 ký tự")]
        public string pregnancy { get; set; }

        [Required]
        [Display(Name = "Rối loạn đông máu")]
        [StringLength(10, ErrorMessage = "Rối loạn đông máu không được vượt quá 10 ký tự")]
        public string bloodDisorder { get; set; }

        [Required]
        [Display(Name = "Dùng chất kích thích")]
        [StringLength(10, ErrorMessage = "Dùng chất kích thích không được vượt quá 10 ký tự")]
        public string useInhibition { get; set; }

        [Required]
        [Display(Name = "Bệnh mãn tính phát triển")]
        [StringLength(10, ErrorMessage = "Bệnh mãn tính phát triển không được vượt quá 10 ký tự")]
        public string developChronic { get; set; }

        [Required]
        [Display(Name = "Khỏi bệnh mãn tính")]
        [StringLength(10, ErrorMessage = "Khỏi bệnh mãn tính không được vượt quá 10 ký tự")]
        public string curedChronic { get; set; }

        [Required]
        [Display(Name = "Đã tiêm 14 ngày")]
        [StringLength(10, ErrorMessage = "Đã tiêm 14 ngày không được vượt quá 10 ký tự")]
        public string vaccineedHalfMonth { get; set; }

        [Required]
        [Display(Name = "Mắc covid trong 6 tháng")]
        [StringLength(10, ErrorMessage = "Mắc covid trong 6 tháng không được vượt quá 10 ký tự")]
        public string covidSixMonths { get; set; }

        [Required]
        [Display(Name = "Đồng ý")]
        [StringLength(10, ErrorMessage = "Đồng ý không được vượt quá 10 ký tự")]
        public string agreement { get; set; }
    }
}
