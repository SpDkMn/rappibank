namespace BancoEntity
{
    public class CuentaBE
    {
        public Guid UsuarioId { get; set; }
        public string NumeroCuenta { get; set; } = "0000-0000-0000-0000";
        public Moneda MonedaCuenta { get; set; }
        public Tipo TipoCuenta { get; set; }
        public double Linea { get; set; } = 0.00;
        public double? Saldo { get; set; } = 0.00;
    }
    public enum Tipo
    {
        Credito,
        Debito
    }
    public enum Moneda
    {
        PEN,
        USD,
        MXN,
        COP
    }
}