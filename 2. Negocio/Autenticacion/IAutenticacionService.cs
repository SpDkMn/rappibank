using Entidades;

namespace Autenticacion
{
    public interface IAutenticacionService
    {
        public AuthEntity? validateAuth(string usuario, string pass);
    }
}
