using System.ComponentModel.DataAnnotations;

namespace IRMS.Model
{
    public class Cultivo
    {
        [Key]
        public int CultivoId { get; set; }
        public string CultivoNombre { get; set; }
        public int NivelAgua { get; set; }
        public string Estado {  get; set; }
        public int DispositivoId { get; set; }
        Dispositivo Dispositivo { get; set; }

    }
}
