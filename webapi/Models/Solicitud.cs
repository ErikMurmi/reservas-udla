namespace webapi.Models
{
    pulic class Solicitud
    {
        public int ID { get; set; }
        public int UsuarioID { get; set; }
        public DateTime Fecha { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; }
        public Usuario UsuarioID { get; set;}
        public Reserva ReservaID { get; set; }
    }
}
