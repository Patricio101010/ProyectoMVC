using Microsoft.EntityFrameworkCore;
using WebAplicacionMVC.Models;

namespace WebAplicacionMVC.Datos
{
    public class ApplicationDbContext : DbContext
    {
        //ctor + tab (autocompletado para crear el contructor)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Agregar los modelos aqui (cada modelo corresponde a una tabla de la BD)
        public DbSet<Contacto> Contactos { get; set; }
    }
}
