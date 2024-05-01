using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRMS.Model
{
    public class AccionXPartida
    {
        public int AccionPartidaId { get; set; }
        public int AccionId { get; set; }
        public Accion Accion { get; set; }
        public int PartidaId { get; set; }
        public Partida Partida { get; set; }
        public DateTime FechaAxP { get; set; }

    }
}
