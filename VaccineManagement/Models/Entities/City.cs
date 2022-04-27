using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models.Entities
{
    public class City
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int cityId { get; set; }

        [Required]
        [Display(Name = "Tỉnh/ thành phố")]
        [StringLength(50, ErrorMessage = "Tên tỉnh/ thành phố không được vượt quá 50 ký tự")]
        public string cityName { get; set; }

        public List<Batch_City> Batch_Cities { get; set; }
        public List<District> Districts { get; set; }
        public List<Vaccination> Vaccinations { get; set; }
    }
}
