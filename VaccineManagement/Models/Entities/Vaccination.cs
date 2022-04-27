using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models.Entities
{
    public class Vaccination
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int vaccinationId { get; set; }

        [Required]
        [Display(Name = "Mã tỉnh/ thành phố")]
        public int cityId { get; set; }

        [Required]
        [Display(Name = "Mã đăng ký")]
        public int registrationId { get; set; }

        [Required]
        [Display(Name = "Mã nhân viên y tế")]
        public int staffId { get; set; }

        [Required]
        [Display(Name = "Mã lô")]
        public int batchId { get; set; }

        [Required]
        [Display(Name = "Ngày tiêm")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime vaccineedDate { get; set; }

        [ForeignKey("batchId")]
        public Vaccine_Batch Vaccine_Batch { get; set; }

        [ForeignKey("cityId")]
        public City City { get; set; }

        [ForeignKey("registrationId")]
        public Vaccine_Registration Vaccine_Registration { get; set; }

        [ForeignKey("staffId")]
        public Medical_Staff Medical_Staff { get; set; }
    }
}
