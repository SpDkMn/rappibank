using BancoEntity;
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
        public IEnumerable<CuentaEntity> Get()
        {
            return contexto.Cuentas;
        }
        public async Task Save(CuentaBE Cuenta)
        {
            CuentaEntity NuevaCuenta = new CuentaEntity();
            NuevaCuenta.CuentaId = new Guid();
            NuevaCuenta.UsuarioId = Cuenta.UsuarioId;
            NuevaCuenta.NumeroCuenta = Cuenta.NumeroCuenta;
            NuevaCuenta.MonedaCuenta = (Entidades.Moneda)Cuenta.MonedaCuenta;
            NuevaCuenta.TipoCuenta = (Entidades.Tipo)Cuenta.TipoCuenta;
            NuevaCuenta.Linea = Cuenta.Linea;
            NuevaCuenta.Saldo = Cuenta.Saldo;
            contexto.Add(NuevaCuenta);
            await contexto.SaveChangesAsync();
        }
        public CuentaEntity? GetCuenta(Guid id)
        {
            var CuentaActual = contexto.Cuentas.Include(p => p.Tarjeta).FirstOrDefault();
            return CuentaActual;
        }
        public async Task Update(Guid id, CuentaBE Cuenta)
        {
            var CuentaActual = contexto.Cuentas.Where(p => p.CuentaId == id).FirstOrDefault();
            if (CuentaActual != null)
            {
                CuentaActual.NumeroCuenta = Cuenta.NumeroCuenta;
                CuentaActual.MonedaCuenta = (Entidades.Moneda)Cuenta.MonedaCuenta;
                CuentaActual.TipoCuenta = (Entidades.Tipo)Cuenta.TipoCuenta;
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
