using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models.Entities
{
    public class Vaccine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int vaccineId { get; set; }

        [Required]
        [Display(Name = "Vaccine")]
        [StringLength(50, ErrorMessage = "Tên Vaccine không được vượt quá 50 ký tự")]
        public string name { get; set; }

        [Required]
        [Display(Name = "Xuất xứ")]
        [StringLength(40, ErrorMessage = "Xuất xứ không được vượt quá 40 ký tự")]
        public string origin { get; set; }

        [Required]
        [Display(Name = "Khoảng cách tiêm")]
        public int maxRange { get; set; }

        [Required]
        [Display(Name = "Bảo quản")]
        public int expired { get; set; }

        [Required]
        [Display(Name = "Số liều")]
        public int doses { get; set; }

        public List<Vaccine_Batch> vaccine_Batches { get; set; }
    }
}
