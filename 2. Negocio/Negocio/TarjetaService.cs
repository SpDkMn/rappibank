using BancoEntity;
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
        public IEnumerable<TarjetaEntity> Get()
        {
            return contexto.Tarjetas;
        }
        public async Task Save(TarjetaBE Tarjeta)
        {
            TarjetaEntity NuevaTarjeta = new TarjetaEntity();
            NuevaTarjeta.TarjetaId = new Guid();
            NuevaTarjeta.CuentaId = Tarjeta.CuentaId;
            NuevaTarjeta.UsuarioId = Tarjeta.UsuarioId;
            NuevaTarjeta.NumeroTarjeta = Tarjeta.NumeroTarjeta;
            NuevaTarjeta.Mes = Tarjeta.Mes;
            NuevaTarjeta.Año = Tarjeta.Año;
            NuevaTarjeta.CVV = Tarjeta.CVV;
            NuevaTarjeta.PIN = Tarjeta.PIN;
            var CuentaExistente = contexto.Cuentas.Where(p => p.CuentaId == NuevaTarjeta.CuentaId).FirstOrDefault();
            var UsuarioExistente = contexto.Usuarios.Where(p => p.UsuarioId == NuevaTarjeta.UsuarioId).FirstOrDefault();
            if (CuentaExistente != null && UsuarioExistente != null) 
            {
                contexto.Add(NuevaTarjeta);
                await contexto.SaveChangesAsync();
            }
            
        }
        public TarjetaEntity? GetTarjeta(Guid id)
        {
            var TarjetaActual = contexto.Tarjetas.Find(id);
            return TarjetaActual;
        }
        public async Task Update(Guid id, TarjetaBE Tarjeta)
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
