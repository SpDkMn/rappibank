using BancoEntity;
using Entidades;

namespace IntefacesNegocios
{
    public interface IMovimientoService
    {
        IEnumerable<MovimientoEntity> Get();
        MovimientoEntity? GetMovimiento(Guid id);
        Task Save(MovimientoBE Movimiento);
        Task Update(Guid id, MovimientoBE Movimiento);
        Task Delete(Guid id);
    }
}
