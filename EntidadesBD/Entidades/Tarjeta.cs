namespace Entidades
{
    public class Tarjeta
    {
        public Guid TarjetaId { get; set; }
        public Guid CuentaId { get; set; }
        public Guid UsuarioId { get; set; }
        public string NumeroTarjeta { get; set; } = "0000 0000 0000 0000";
        public int Mes { get; set; }
        public int Año { get; set; }
        public string CVV { get; set; }
        public string PIN { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual Cuenta? Cuenta { get; set; }
    }
}