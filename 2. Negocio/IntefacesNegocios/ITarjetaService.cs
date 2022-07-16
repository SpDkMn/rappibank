using Entidades;

namespace IntefacesNegocios
{
    public interface ITarjetaService
    {
        IEnumerable<Tarjeta> Get();
        Tarjeta? GetTarjeta(Guid id);
        Task Save(Tarjeta Tarjeta);
        Task Update(Guid id, Tarjeta Tarjeta);
        Task Delete(Guid id);
    }
}
