using System.ComponentModel.DataAnnotations;    
namespace IRMS.Model
{
    public class Jugador
    {
        [Key]
        public int JugadorId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos {  get; set; }
        public string NombreUsuario { get; set; }
        public string password { get; set; }
        public string photo { get; set; }
        public string Email { get; set; }

    }
}
