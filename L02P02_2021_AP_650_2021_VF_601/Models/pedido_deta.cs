using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace L02P02_2021_AP_650_2021_VF_601.Models
{
    public class pedido_deta
    {
        public pedido_deta()
        {
            created_at = DateTime.Now;
        }
        [Key]
        public int id { get; set; }

        public int? id_pedido { get; set; }

        public int? id_libro { get; set; }

        public DateTime created_at { get; set; }
    }
}
