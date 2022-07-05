using Entidades;

namespace Autenticacion
{
    public interface IAutenticacionService
    {
        public Auth? validateAuth(string usuario, string pass);
    }
}
