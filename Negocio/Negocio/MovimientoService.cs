using Contexto;
using Entidades;
using IntefacesNegocios;

namespace Negocio
{
    public class MovimientoService : IMovimientoService
    {
        BancoContexto contexto;
        public MovimientoService(BancoContexto contextoBD)
        {
            contexto = contextoBD;
        }
        public IEnumerable<Movimiento> Get()
        {
            return contexto.Movimientos;
        }
        public async Task Save(Movimiento Movimiento)
        {
            var cuentaActual = contexto.Cuentas.Where(p => p.CuentaId == Movimiento.CuentaId).FirstOrDefault();
            if( cuentaActual != null)
            {
                if( (Movimiento.Monto < 0 && cuentaActual.Saldo >= Movimiento.Monto*(-1)) || Movimiento.Monto > 0 )
                {
                    cuentaActual.Saldo += Movimiento.Monto;
                    Movimiento.MovimientoId = new Guid();
                    contexto.Add(Movimiento);
                }
            }
            await contexto.SaveChangesAsync();
        }
        public Movimiento? GetMovimiento(Guid id)
        {
            var MovimientoActual = contexto.Movimientos.Find(id);
            return MovimientoActual;
        }
        public async Task Update(Guid id, Movimiento Movimiento)
        {
            var MovimientoActual = contexto.Movimientos.Find(id);

            if (MovimientoActual != null)
            {
                MovimientoActual.CuentaId = Movimiento.CuentaId;
                MovimientoActual.Monto = Movimiento.Monto;
                MovimientoActual.Origen = Movimiento.Origen;

                await contexto.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            var MovimientoActual = contexto.Movimientos.Find(id);

            if (MovimientoActual != null)
            {
                contexto.Remove(MovimientoActual);
                await contexto.SaveChangesAsync();
            }
        }

    }
}
