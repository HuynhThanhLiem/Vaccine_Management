using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models.Entities
{
    public class Citizen
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int citizenId { get; set; }

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

        public List<Health_Declaration> Health_Declarations { get; set; }
        public List<Vaccine_Registration> Vaccine_Registrations { get; set; }
    }
}
