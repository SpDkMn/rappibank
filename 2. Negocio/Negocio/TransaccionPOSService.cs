using Contexto;
using Entidades;
using IntefacesNegocios;
using POSEntity;

namespace Negocio
{
    public class TransaccionPOSService : ITransaccionPOSService
    {
        BancoContexto contexto;
        public TransaccionPOSService(BancoContexto contextoBD)
        {
            contexto = contextoBD;
        }
        public async Task<bool> Save(TransaccionPOSBE Transaccion)
        {
            var TarjetaExistente = contexto.Tarjetas.Where(p => p.NumeroTarjeta.Equals(Transaccion.NumeroTarjeta)).Where(p => p.PIN.Equals(Transaccion.PIN)).FirstOrDefault();
            if (TarjetaExistente == null) return false;
            MovimientoEntity NuevoMovimiento = new MovimientoEntity();
            NuevoMovimiento.MovimientoId = new Guid();
            NuevoMovimiento.Monto = (-1)*Transaccion.Monto;
            NuevoMovimiento.Origen = Entidades.Origen.POS;
            NuevoMovimiento.CuentaId = TarjetaExistente.CuentaId;
            var cuentaActual = contexto.Cuentas.Where(p => p.CuentaId == TarjetaExistente.CuentaId).FirstOrDefault();
            if (cuentaActual == null) return false;
            if (
                (NuevoMovimiento.Monto < 0 && cuentaActual.Saldo >= NuevoMovimiento.Monto * (-1)) ||
                NuevoMovimiento.Monto > 0
             )
            {
                cuentaActual.Saldo += NuevoMovimiento.Monto;
                contexto.Add(NuevoMovimiento);
                await contexto.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
