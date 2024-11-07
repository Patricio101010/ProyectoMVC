using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
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

        public async Task<IActionResult> Index()
        {
            return View(await _contexto.Contactos.ToListAsync());
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
