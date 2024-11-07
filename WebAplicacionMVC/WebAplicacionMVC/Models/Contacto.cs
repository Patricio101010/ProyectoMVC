using System.ComponentModel.DataAnnotations;

namespace WebAplicacionMVC.Models
{
    public class Contacto
    {
        /* La anotación [Key] en .NET Core (dentro de Entity Framework Core) se utiliza para designar una propiedad como clave primaria en una entidad. 
         * Cuando estás trabajando con clases de modelo en una base de datos usando Entity Framework Core, 
         * puedes decorar la propiedad de identificación con [Key] para asegurarte de que se reconoce como la clave primaria. 
         * Si la propiedad se llama Id o NombreClaseId, Entity Framework suele detectarla automáticamente como clave primaria,
         * por lo que la anotación [Key] no es estrictamente necesaria en estos casos. 
         * Sin embargo, es útil en situaciones donde quieres especificar explícitamente qué propiedad debe actuar como clave. */

        [Key] //Indica que esta propiedad es la clave primaria
        public int Id { get; set; } // En el caso de Id o ContactoId, puedes omitir [Key] si solo tienes una propiedad que actúe como clave.

        //prop + tab (para crear la linea con los atributos de la clase)
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El telefono es obligatorio")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "El celular es obligatorio")]
        public string Celular { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El fecha creacion es obligatorio")]
        public DateTime  FechaCreacion{ get; set; }
    }

}
