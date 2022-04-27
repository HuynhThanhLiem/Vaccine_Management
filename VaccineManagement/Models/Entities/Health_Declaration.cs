using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models.Entities
{
    public class Health_Declaration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int healthDeclarId { get; set; }

        [Required]
        [Display(Name = "Mã công dân")]
        public int citizenId { get; set; }

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
        [Display(Name = "Ngày khai báo")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime declaratedDate { get; set; }

        [ForeignKey("citizenId")]
        public Citizen Citizen { get; set; }
    }
}
