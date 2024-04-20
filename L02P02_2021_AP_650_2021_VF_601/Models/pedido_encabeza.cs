using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2021_AP_650_2021_VF_601.Models
{
    public class pedido_encabeza
    {
        [Key]
        public int id { get; set; }

        public int? id_cliente { get; set; }

        public int cantidad_libros { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal total { get; set; }
    }
}
