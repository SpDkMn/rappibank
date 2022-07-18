namespace Entidades
{
    public class MovimientoEntity
    {
        public Guid MovimientoId { get; set; }
        public Guid CuentaId { get; set; }
        public double Monto { get; set; } = 0.00;
        public Origen Origen { get; set; }
        public virtual CuentaEntity? Cuenta { get; set; }
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