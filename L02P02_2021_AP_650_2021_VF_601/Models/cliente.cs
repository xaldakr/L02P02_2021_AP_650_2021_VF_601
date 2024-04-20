using System.ComponentModel.DataAnnotations;

namespace L02P02_2021_AP_650_2021_VF_601.Models
{
    public class cliente
    {
        public cliente() { 
            created_at = DateTime.Now;
        }

        [Key]
        public int id { get; set; }
        [Required (ErrorMessage = "El nombre es obligatorio")]
        [StringLength (255, ErrorMessage = "Solo puedes usar como máximo 255 carácteres")]
        public string? nombre { get; set; }
        [Required (ErrorMessage = "El apellido es obligatorio")]
        [StringLength(255, ErrorMessage = "Solo puedes usar como máximo 255 carácteres")]
        public string? apellido { get; set; }
        [Required(ErrorMessage = "El email es obligatorio")]
        [StringLength(255, ErrorMessage = "Solo puedes usar como máximo 255 carácteres")]
        public string? email { get; set; }
        [Required(ErrorMessage = "La direccion es obligatoria")]
        [StringLength(255, ErrorMessage = "Solo puedes usar como máximo 255 carácteres")]
        public string? direccion { get; set; }

        public DateTime? created_at { get; set; }
    }
}
