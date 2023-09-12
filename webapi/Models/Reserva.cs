namespace webapi.Models
{
    public class Reserva
    {
        public int ID { get; set; }
        public Solicitud SolicitudID { get; set; }
        public Cancha CanchaID { get; set; }
        public DateOnly Fecha { get; set; }
        public TimeOnly Hora_inicio { get; set; }
        public TimeOnly Hora_fin { get; set; }
        public string Estado { get; set; }
    }
}
