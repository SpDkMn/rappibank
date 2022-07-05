using Contexto;
using Entidades;
using IntefacesNegocios;

namespace Negocio
{
    public class TarjetaService : ITarjetaService
    {
        BancoContexto contexto;
        public TarjetaService(BancoContexto contextoBD)
        {
            contexto = contextoBD;
        }
        public IEnumerable<Tarjeta> Get()
        {
            return contexto.Tarjetas;
        }
        public async Task Save(Tarjeta Tarjeta)
        {
            var TarjetaExistente = contexto.Tarjetas.Where(p => p.CuentaId == Tarjeta.CuentaId).FirstOrDefault();
            if (TarjetaExistente == null ) 
            {
                Tarjeta.TarjetaId = new Guid();
                contexto.Add(Tarjeta);
                await contexto.SaveChangesAsync();
            }
            
        }
        public Tarjeta? GetTarjeta(Guid id)
        {
            var TarjetaActual = contexto.Tarjetas.Find(id);
            return TarjetaActual;
        }
        public async Task Update(Guid id, Tarjeta Tarjeta)
        {
            var TarjetaActual = contexto.Tarjetas.Find(id);

            if (TarjetaActual != null)
            {
                TarjetaActual.CuentaId = Tarjeta.CuentaId;
                TarjetaActual.UsuarioId = Tarjeta.UsuarioId;
                TarjetaActual.NumeroTarjeta = Tarjeta.NumeroTarjeta;
                TarjetaActual.Mes = Tarjeta.Mes;
                TarjetaActual.Año = Tarjeta.Año;
                TarjetaActual.CVV = Tarjeta.CVV;
                TarjetaActual.PIN = Tarjeta.PIN;

                await contexto.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            var TarjetaActual = contexto.Tarjetas.Find(id);

            if (TarjetaActual != null)
            {
                contexto.Remove(TarjetaActual);
                await contexto.SaveChangesAsync();
            }
        }
    }
}
