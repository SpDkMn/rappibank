using BancoEntity;
using Entidades;

namespace IntefacesNegocios
{
    public interface ITarjetaService
    {
        IEnumerable<TarjetaEntity> Get();
        TarjetaEntity? GetTarjeta(Guid id);
        Task Save(TarjetaBE Tarjeta);
        Task Update(Guid id, TarjetaBE Tarjeta);
        Task Delete(Guid id);
    }
}
