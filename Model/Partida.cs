    using System.ComponentModel.DataAnnotations;
namespace IRMS.Model
{
    public class Partida
    {
        [Key]
        public int PartidaId { get; set; }
        public int GranjaId {  get; set; }
        public Granja Granja { get; set; }
        public string Puntuacion { get; set; }
        public DateTime FechaGuardado { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string PartidaEstado {  get; set; }
        public int JugadorId { get; set; }
        public Jugador Jugador { get; set; }


    }
}
