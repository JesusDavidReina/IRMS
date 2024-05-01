using System.ComponentModel.DataAnnotations;

namespace IRMS.Model
{
    public class Clima
    {
        [Key]
        public int ClimaId { get; set; }
        public string NombreClima { get; set; }
        public string EfectoClima { get; set; }
    }
}
