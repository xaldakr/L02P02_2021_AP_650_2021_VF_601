using L02P02_2021_AP_650_2021_VF_601.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace L02P02_2021_AP_650_2021_VF_601.Controllers
{
    public class VentaController : Controller
    {
        public pedido_encabeza Encabeza;
        public cliente Client;

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
            _LibreriaContext.Add(Clie);
            _LibreriaContext.SaveChanges();
            int idclie = _LibreriaContext.clientes.Select(c => (int?)c.id).Max() ?? 0; // Obtener id de pedido
            Encabeza = new pedido_encabeza();
            Encabeza.id_cliente = idclie;
            Encabeza.total = 0;
            Encabeza.cantidad_libros = 0;
            Encabeza.estado = "P";
            _LibreriaContext.Add(Encabeza);
            _LibreriaContext.SaveChanges();
            int idencabeza = _LibreriaContext.pedido_encabezado.Select(c => (int?)c.id).Max() ?? 0; //Obtener el id del encabezado;
            Encabeza = (pedido_encabeza)(from e in _LibreriaContext.pedido_encabezado where e.id == idencabeza select e);
            Client = (cliente)(from e in _LibreriaContext.clientes where e.id == idclie select e);
            return RedirectToAction("ListaLibros");
        }
        public IActionResult MandarFin()
        {
            return RedirectToAction("confirmVenta");
        }
        public IActionResult ListaLibros()
        {
            var listalibros = (from e in _LibreriaContext.libros
                                join a in _LibreriaContext.autores on e.id_autor equals a.id
                                select new
                                {
                                    id = e.id,
                                    nombre = e.nombre,
                                    autor = a.autor,
                                    precio = e.precio
                                }).ToList();
            ViewData["listaLibros"] = listalibros;
            return View();
        }
        public IActionResult confirmVenta()
        {
            return View();  
        }
        public IActionResult Agregar(int id, decimal precio)
        {
            pedido_deta pedido_Deta = new pedido_deta();
            pedido_Deta.id_libro = id;
            pedido_Deta.id_pedido = Encabeza.id;
            _LibreriaContext.Add(pedido_Deta);
            _LibreriaContext.SaveChanges();
            pedido_encabeza? alterPed = (from e in _LibreriaContext.pedido_encabezado
                                         where e.id == Encabeza.id
                                         select e).FirstOrDefault();
            alterPed.total += precio;
            alterPed.cantidad_libros++;
            Encabeza = alterPed;
            _LibreriaContext.Entry(alterPed).State = EntityState.Modified;
            _LibreriaContext.SaveChanges();
            return RedirectToAction("ListaLibros");

        }
    }
}
