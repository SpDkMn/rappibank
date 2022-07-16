using Contexto;
using Entidades;
using IntefacesNegocios;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class CuentaService : ICuentaService
    {
        BancoContexto contexto;
        public CuentaService(BancoContexto contextoBD)
        {
            contexto = contextoBD;
        }
        public IEnumerable<Cuenta> Get()
        {
            return contexto.Cuentas;
        }
        public async Task Save(Cuenta Cuenta)
        {
            Cuenta.CuentaId = new Guid();
            contexto.Add(Cuenta);
            await contexto.SaveChangesAsync();
        }
        public Cuenta? GetCuenta(Guid id)
        {
            var CuentaActual = contexto.Cuentas.Include(p => p.Tarjeta).FirstOrDefault();
            return CuentaActual;
        }
        public async Task Update(Guid id, Cuenta Cuenta)
        {
            var CuentaActual = contexto.Cuentas.Where(p => p.CuentaId == id).FirstOrDefault();

            if (CuentaActual != null)
            {
                CuentaActual.NumeroCuenta = Cuenta.NumeroCuenta;
                CuentaActual.MonedaCuenta = Cuenta.MonedaCuenta;
                CuentaActual.TipoCuenta = Cuenta.TipoCuenta;
                CuentaActual.Linea = Cuenta.Linea;
                CuentaActual.Saldo = Cuenta.Saldo;

                await contexto.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            var CuentaActual = contexto.Cuentas.Find(id);

            if (CuentaActual != null)
            {
                contexto.Remove(CuentaActual);
                await contexto.SaveChangesAsync();
            }
        }
    }
}
