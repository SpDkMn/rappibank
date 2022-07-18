namespace Entidades
{
    public class TarjetaEntity
    {
        public Guid TarjetaId { get; set; }
        public Guid CuentaId { get; set; }
        public Guid UsuarioId { get; set; }
        public string NumeroTarjeta { get; set; } = "0000 0000 0000 0000";
        public int Mes { get; set; }
        public int Año { get; set; }
        public string CVV { get; set; }
        public string PIN { get; set; }
        public virtual UsuarioEntity? Usuario { get; set; }
        public virtual CuentaEntity? Cuenta { get; set; }
    }
}