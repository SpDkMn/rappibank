namespace POSEntity
{
    public class TransaccionPOSBE
    {
        public string NumeroTarjeta { get; set; }
        public string PIN { get; set; }
        public double Monto { get; set; } = 0.00;
    }
}