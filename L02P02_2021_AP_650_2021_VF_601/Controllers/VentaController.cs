using L02P02_2021_AP_650_2021_VF_601.Models;
using Microsoft.AspNetCore.Mvc;

namespace L02P02_2021_AP_650_2021_VF_601.Controllers
{
    public class VentaController : Controller
    {
        public pedido_encabeza Encabeza;
        public pedido_deta Detalle;
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult IniciarVenta (cliente Clie)
        {
            return RedirectToAction("Index"); // Llevalo al siguiente view en vez de index
        }

        public IActionResult ListaLibros()
        {
            return View();
        }
    }
}
