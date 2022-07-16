using Entidades;

namespace IntefacesNegocios
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> Get();
        Usuario? GetUsuario(Guid id);
        Task Save(Usuario Usuario);
        Task Update(Guid id, Usuario Usuario);
        Task Delete(Guid id);
    }
}