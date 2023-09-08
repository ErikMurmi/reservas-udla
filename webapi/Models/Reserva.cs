namespace webapi.Models
{
    pulic class Reserva
    {
        public int ID { get; set; }
        public int SolicitudID { get; set; }
        public int CanchaID { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Hora_inicio { get; set; }
        public TimeSpan Hora_fin { get; set; }
        public string Estado { get; set; }
    }
}
