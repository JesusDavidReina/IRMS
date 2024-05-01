using System.ComponentModel.DataAnnotations;

namespace IRMS.Model
{
    public class Dispositivo
    {
        [Key]
        public int DispositivoId { get; set; }
        public string NombreDispositivo { get; set; }
        public string Descripcion { get; set; }
        public int TipoDispositivoId { get; set; }
        TipoDispositivo TipoDispositivo { get; set; }
    }
}
