using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models.Entities
{
    public class District
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int districtId { get; set; }

        [Required]
        [Display(Name = "Mã tỉnh/ thành phố")]
        public int cityId { get; set; }

        [Required]
        [Display(Name = "Quận/ huyện")]
        [StringLength(50, ErrorMessage = "Tên quận/ huyện không được vượt quá 50 ký tự")]
        public string districtName { get; set; }

        [ForeignKey("cityId")]
        public City City { get; set; }

        public List<Ward> Wards { get; set; }
    }
}
