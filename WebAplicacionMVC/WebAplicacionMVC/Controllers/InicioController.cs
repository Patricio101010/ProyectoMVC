using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using WebAplicacionMVC.Datos;
using WebAplicacionMVC.Models;

namespace WebAplicacionMVC.Controllers
{
    public class InicioController : Controller
    {
        //private readonly ILogger<InicioController> _logger;

        //public InicioController(ILogger<InicioController> logger)
        //{
        //    _logger = logger;
        //}

        private readonly ApplicationDbContext _contexto;
        public InicioController(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Contactos.ToListAsync());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                contacto.FechaCreacion = DateTime.Now;

                _contexto.Contactos.Add(contacto);
                await _contexto.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [HttpGet]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _contexto.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Contacto contacto)
        {
            if (ModelState.IsValid)
            {
                _contexto.Update(contacto);
                await _contexto.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Detalle(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _contexto.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        [HttpGet]
        public async Task<IActionResult> Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contacto = await _contexto.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return NotFound();
            }

            return View(contacto);
        }

        [HttpPost, ActionName("Borrar")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> BorrarContacto(int? id)
        {
            var contacto = await _contexto.Contactos.FindAsync(id);
            if (contacto == null)
            {
                return View();
            }

            //borrado
            _contexto.Contactos.Remove(contacto);
            await _contexto.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
