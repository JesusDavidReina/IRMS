using System.ComponentModel.DataAnnotations;

namespace IRMS.Model
{
    public class TipoDispositivo
    {
        [Key]
        public int TipoDispositivoId { get; set; }
        public string  NombreTipoDispositivo {  get; set; }

    }
}
