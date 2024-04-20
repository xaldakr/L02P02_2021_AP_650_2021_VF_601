using System.ComponentModel.DataAnnotations;

namespace L02P02_2021_AP_650_2021_VF_601.Models
{
    public class autore
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(200, ErrorMessage = "Solo puedes usar como máximo 200 carácteres")]
        public string autor { get; set; }
    }
}
