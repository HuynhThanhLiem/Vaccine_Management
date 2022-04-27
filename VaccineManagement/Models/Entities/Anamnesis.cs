using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models.Entities
{
    public class Anamnesis
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int anamnesisId { get; set; }

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

        public List<Vaccine_Registration> Vaccine_Registrations { get; set; }
    }
}
