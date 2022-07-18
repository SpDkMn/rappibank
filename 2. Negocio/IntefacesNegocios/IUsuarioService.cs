using BancoEntity;
using Entidades;

namespace IntefacesNegocios
{
    public interface IUsuarioService
    {
        IEnumerable<UsuarioEntity> Get();
        UsuarioEntity? GetUsuario(Guid id);
        Task Save(UsuarioBE Usuario);
        Task Update(Guid id, UsuarioBE Usuario);
        Task Delete(Guid id);
    }
}