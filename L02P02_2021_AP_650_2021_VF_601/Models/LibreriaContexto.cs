using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
namespace L02P02_2021_AP_650_2021_VF_601.Models
{
    public class LibreriaContexto:DbContext
    {
        public LibreriaContexto(DbContextOptions<LibreriaContexto> options) : base(options)
        {

        }
        public DbSet<autore> autores { get; set; }
        public DbSet<categor> categorias { get; set; }
        public DbSet<cliente> clientes { get; set; }
        public DbSet<libro> libros { get; set; }
        public DbSet<pedido_deta> pedido_detalle { get; set; }
        public DbSet<pedido_encabeza> pedido_encabezado { get; set; }
    }
}
