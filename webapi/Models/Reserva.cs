namespace webapi.Models
{
    public class Reserva
    {
        public int ID { get; set; }
        public Solicitud SolicitudID { get; set; }
        public Cancha CanchaID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora_inicio { get; set; }
        public TimeSpan Hora_fin { get; set; }
        public string Estado { get; set; }
    }
}
