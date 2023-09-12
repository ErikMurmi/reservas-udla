namespace webapi.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public int ID_Banner { get; set; }
        public string Carrera { get; set; }
        public Solicitud Solicitud { get; set; }
    }
}
