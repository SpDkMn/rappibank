namespace BancoEntity
{
    public class MovimientoBE
    {
        public Guid CuentaId { get; set; }
        public double Monto { get; set; } = 0.00;
        public Origen Origen { get; set; }
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
