using Entidades;

namespace IntefacesNegocios
{
    public interface ICuentaService
    {
        IEnumerable<Cuenta> Get();
        Cuenta? GetCuenta(Guid id);
        Task Save(Cuenta Cuenta);
        Task Update(Guid id, Cuenta Cuenta);
        Task Delete(Guid id);
    }
}