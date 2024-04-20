using L02P02_2021_AP_650_2021_VF_601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L02P02_2021_AP_650_2021_VF_601.Controllers
{
    public class VentaController : Controller
    {
        public pedido_encabeza Encabeza;
        public pedido_deta Detalle;

        private readonly LibreriaContexto _LibreriaContext;
        public VentaController(LibreriaContexto LibreriaContext)
        {
            _LibreriaContext = LibreriaContext;
        }
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult IniciarVenta (cliente Clie)
        {
            /*
            _LibreriaContext.Add(Clie);
            _LibreriaContext.SaveChanges();
            int idclie = _LibreriaContext.clientes.Select(c => (int?)c.id).Max() ?? 0; // Obtener id de pedido
            Encabeza = new pedido_encabeza();
            Encabeza.id_cliente = idclie;
            Encabeza.total = 0;
            Encabeza.cantidad_libros = 0;
            _LibreriaContext.Add(Encabeza);
            _LibreriaContext.SaveChanges();
            int idencabeza = _LibreriaContext.pedido_encabezado.Select(c => (int?)c.id).Max() ?? 0; //Obtener el id del encabezado;
            Encabeza = (pedido_encabeza)(from e in _LibreriaContext.pedido_encabezado where e.id == idencabeza select e);
            */
            return RedirectToAction("ListaLibros");
        }

        public IActionResult ListaLibros()
        {
            return View();
        }
        public IActionResult confirmVenta()
        {
            return View();  
        }
    }
}
