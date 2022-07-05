using System.Text.Json.Serialization;

namespace Entidades
{
    public class Usuario
    {
        public Guid UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Edad { get; set; }
        public string ContraseñaWeb { get; set; }
        public virtual ICollection<Cuenta>? Cuentas { get; set; }
        [JsonIgnore] 
        public virtual ICollection<Tarjeta>? Tarjetas { get; set; }
    }
}