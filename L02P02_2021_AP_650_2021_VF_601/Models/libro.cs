using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace L02P02_2021_AP_650_2021_VF_601.Models
{
    public class libro
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Solo puedes usar como máximo 255 carácteres")]
        public string? nombre { get; set; }

        [StringLength(255, ErrorMessage = "Solo puedes usar como máximo 255 carácteres")]
        public string? descripcion { get; set; }

        [StringLength(255, ErrorMessage = "Solo puedes usar como máximo 255 carácteres")]
        public string? url_imagen { get; set; }

        public int? id_autor { get; set; }

        public int? id_categoria { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal precio { get; set; }

        [StringLength(1)]
        public string? estado { get; set; }

    }
}
