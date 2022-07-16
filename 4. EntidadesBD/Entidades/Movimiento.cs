namespace Entidades
{
    public class Movimiento
    {
        public Guid MovimientoId { get; set; }
        public Guid CuentaId { get; set; }
        public double Monto { get; set; } = 0.00;
        public Origen Origen { get; set; }
        public virtual Cuenta? Cuenta { get; set; }
    }
    public enum Origen
    {
        WEB,
        POS,
        CAJERO,
        PAGOLINK,
        APLICACION
    }
}