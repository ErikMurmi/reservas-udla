namespace webapi.Models
{
    public class Cancha
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Campus { get; set; }
        public TimeOnly Hora_inicio { get; set; }
        public TimeOnly Hora_fin { get; set; }
        public string Deporte { get; set; }
        public bool Habilitada { get; set; }
        public Solicitud Solicitud { get; set; }
        public Reserva Reserva { get; set; }
    }
}
