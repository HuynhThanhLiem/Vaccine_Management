using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models.Entities
{
    public class Batch_City
    {
        [Display(Name = "Mã tỉnh/thành phố")]
        public int cityId { get; set; }

        [Display(Name = "Mã lô")]
        public int batchId { get; set; }

        [Required]
        [Display(Name = "Số lượng")]
        public int quantityVaccine { get; set; }

        [Required]
        [Display(Name = "Ngày vận chuyển")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime shippedDate { get; set; }

        [ForeignKey("cityId")]
        public City City { get; set; }

        [ForeignKey("batchId")]
        public Vaccine_Batch Vaccine_Batch { get; set; }
    }
}
