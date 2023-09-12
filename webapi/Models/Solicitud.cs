namespace webapi.Models
{
    public class Solicitud
    {
        public int ID { get; set; }
        public Usuario UsuarioID { get; set; }
        public Cancha CanchaID { get; set; }
        public DateOnly Fecha { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
        public Reserva Reserva { get; set; }
    }
}
