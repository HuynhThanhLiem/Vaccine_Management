using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models.Entities
{
    public class Vaccine_Batch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int batchId { get; set; }

        [Required]
        [Display(Name = "Batch Name")]
        [StringLength(50, ErrorMessage = "Tên lô Vaccine không được vượt quá 50 ký tự")]
        public string batchName { get; set; }

        [Required]
        [Display(Name = "Vaccine")]
        public int vaccineId { get; set; }

        [Required]
        [Display(Name = "Ngày nhập")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime importedDate { get; set; }

        [Required]
        [Display(Name = "Số lượng")]
        public int quantity { get; set; }

        [Required]
        [Display(Name = "Ngày sản xuất")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime producedDate { get; set; }

        [Required]
        [Display(Name = "Ngày hết hạn")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime expiredDate { get; set; }

        [ForeignKey("vaccineId")]
        public Vaccine Vaccine { get; set; }

        public List<Batch_City> Batch_Cities { get; set; }
        public List<Vaccination> Vaccinations { get; set; }
    }
}
