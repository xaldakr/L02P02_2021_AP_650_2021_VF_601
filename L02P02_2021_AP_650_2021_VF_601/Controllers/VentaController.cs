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
            if (Encabeza == null || Client == null)
            {
                return RedirectToAction("Index");
            }
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
            ViewBag.cabeza = Encabeza;
            return View();
        }
        public IActionResult confirmVenta()
        {
            if (Encabeza == null || Client == null)
            {
                return RedirectToAction("Index");
            }
            var listacarro = (from e in _LibreriaContext.pedido_detalle
                               join cab in _LibreriaContext.pedido_encabezado on e.id_pedido equals cab.id
                               join l in _LibreriaContext.libros on e.id_libro equals l.id
                               join a in _LibreriaContext.autores on l.id_autor equals a.id
                              where cab.id == Encabeza.id
                               select new
                               {
                                   nombre = l.nombre,
                                   autor = a.autor,
                                   precio = l.precio
                               }).ToList();
            ViewData["listaCarro"] = listacarro;
            ViewBag.cliente = Client;
            ViewBag.cabezon = Encabeza;
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

        public IActionResult Finalizar() {
            
            pedido_encabeza? alterPedi = (from e in _LibreriaContext.pedido_encabezado
                                         where e.id == Encabeza.id
                                         select e).FirstOrDefault();
            alterPedi.estado = "C";
            _LibreriaContext.Entry(alterPedi).State = EntityState.Modified;
            _LibreriaContext.SaveChanges();
            Encabeza = null;
            Client = null;
            TempData["Mensaje"] = "Compra realizada Correctamente!!!";
            return RedirectToAction("Index");
        }
    }
}
