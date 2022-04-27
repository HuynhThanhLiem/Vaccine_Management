using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VaccineManagement.Models.Entities
{
    public class Ward
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int wardId { get; set; }

        [Required]
        [Display(Name = "Mã quận/ huyện")]
        public int districtId { get; set; }

        [Required]
        [Display(Name = "Xã/ phường/ thị trấn")]
        [StringLength(50, ErrorMessage = "Tên xã/ phường/ thị trấn không được vượt quá 50 ký tự")]
        public string wardName { get; set; }

        [ForeignKey("districtId")]
        public District District { get; set; }
    }
}
