using BancoEntity;
using Entidades;

namespace IntefacesNegocios
{
    public interface ICuentaService
    {
        IEnumerable<CuentaEntity> Get();
        CuentaEntity? GetCuenta(Guid id);
        Task Save(CuentaBE Cuenta);
        Task Update(Guid id, CuentaBE Cuenta);
        Task Delete(Guid id);
    }
}