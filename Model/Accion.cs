using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace IRMS.Model
{
    public class Accion
    {
        [Key]
        public int AccionId { get; set; }
        public string NombreAccion { get; set;}
        public string Descripcion { get; set;}
        public int DispositivoId { get; set; }
        Dispositivo Dispositivo { get; set; }
    }
}
