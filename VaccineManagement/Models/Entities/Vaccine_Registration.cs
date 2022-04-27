using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models.Entities
{
    public class Vaccine_Registration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int registrationId { get; set; }

        [Required]
        [Display(Name = "Mã công dân")]
        public int citizenId { get; set; }

        [Required]
        [Display(Name = "Mã tiền sử bệnh")]
        public int anamnesisId { get; set; }

        [Required]
        [Display(Name = "Đồng ý")]
        [StringLength(10, ErrorMessage = "Đồng ý không được vượt quá 10 ký tự")]
        public string agreement { get; set; }

        [Required]
        [Display(Name = "Mũi tiêm")]
        public int choiceInjections { get; set; }

        [Required]
        [Display(Name = "Ngày đăng ký")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime registratedDate { get; set; }

        [Required]
        [Display(Name = "Trạng thái")]
        [StringLength(50, ErrorMessage = "Trạng thái không được vượt quá 50 ký tự")]
        public string status { get; set; }

        [ForeignKey("citizenId")]
        public Citizen Citizen { get; set; }
        [ForeignKey("anamnesisId")]
        public Anamnesis Anamnesis { get; set; }

        public List<Vaccination> Vaccinations { get; set; }
    }
}
