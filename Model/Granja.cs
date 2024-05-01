using System.ComponentModel.DataAnnotations;
namespace IRMS.Model
{
    public class Granja
    {
        [Key]
        public int GranjaId { get; set; }
        public string NombreGranja { get; set; }
        public int CultivoId {  get; set; }
        public Cultivo Cultivo { get; set; }
        public int ClimaId { get; set; }
        public Clima Clima { get; set; } 
        public string SistemaRiego { get; set; }
        public string Dificultad {  get; set; }
    }
}
