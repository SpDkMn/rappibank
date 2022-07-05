using Entidades;

namespace IntefacesNegocios
{
    public interface IMovimientoService
    {
        IEnumerable<Movimiento> Get();
        Movimiento? GetMovimiento(Guid id);
        Task Save(Movimiento Movimiento);
        Task Update(Guid id, Movimiento Movimiento);
        Task Delete(Guid id);
    }
}
