using System.Text.Json.Serialization;

namespace Entidades
{
    public class UsuarioEntity
    {
        public Guid UsuarioId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Edad { get; set; }
        public string ContraseñaWeb { get; set; }
        public virtual ICollection<CuentaEntity>? Cuentas { get; set; }
        [JsonIgnore] 
        public virtual ICollection<TarjetaEntity>? Tarjetas { get; set; }
    }
}