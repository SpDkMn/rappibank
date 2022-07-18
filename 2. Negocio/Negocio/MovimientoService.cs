using BancoEntity;
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
        public IEnumerable<MovimientoEntity> Get()
        {
            return contexto.Movimientos;
        }
        public async Task Save(MovimientoBE Movimiento)
        {
            MovimientoEntity NuevoMovimiento = new MovimientoEntity();
            NuevoMovimiento.MovimientoId = new Guid();
            NuevoMovimiento.Monto = Movimiento.Monto;
            NuevoMovimiento.Origen = (Entidades.Origen)Movimiento.Origen;
            NuevoMovimiento.CuentaId = Movimiento.CuentaId;

            var cuentaActual = contexto.Cuentas.Where(p => p.CuentaId == NuevoMovimiento.CuentaId)
                .FirstOrDefault();
            if( cuentaActual != null)
            {
                if( 
                    (NuevoMovimiento.Monto < 0 && cuentaActual.Saldo >= NuevoMovimiento.Monto*(-1)) || 
                    Movimiento.Monto > 0 
                )
                {
                    cuentaActual.Saldo += NuevoMovimiento.Monto;
                    contexto.Add(NuevoMovimiento);
                }
            }
            await contexto.SaveChangesAsync();
        }
        public MovimientoEntity? GetMovimiento(Guid id)
        {
            var MovimientoActual = contexto.Movimientos.Find(id);
            return MovimientoActual;
        }
        public async Task Update(Guid id, MovimientoBE Movimiento)
        {
            var MovimientoActual = contexto.Movimientos.Find(id);

            if (MovimientoActual != null)
            {
                MovimientoActual.Monto = Movimiento.Monto;
                MovimientoActual.Origen = (Entidades.Origen)Movimiento.Origen;
                MovimientoActual.CuentaId = Movimiento.CuentaId;
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
