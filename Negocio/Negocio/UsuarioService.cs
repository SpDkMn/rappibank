using Contexto;
using Entidades;
using IntefacesNegocios;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class UsuarioService : IUsuarioService
    {
        BancoContexto contexto;
        public UsuarioService(BancoContexto contextoBD)
        {
            contexto = contextoBD;
        }
        public IEnumerable<Usuario> Get()
        {
            return contexto.Usuarios;
        }
        public async Task Save(Usuario Usuario)
        {
            Usuario.UsuarioId = new Guid();
            contexto.Add(Usuario);
            await contexto.SaveChangesAsync();
        }
        public Usuario? GetUsuario(Guid id)
        {
            var UsuarioActual = contexto.Usuarios.Include(p => p.Cuentas).Where(p => p.UsuarioId == id).FirstOrDefault();  //.Find(id);
            return UsuarioActual;
        }
        public async Task Update(Guid id, Usuario Usuario)
        {
            var UsuarioActual = contexto.Usuarios.Find(id);

            if (UsuarioActual != null)
            {
                UsuarioActual.Nombres = Usuario.Nombres;
                UsuarioActual.Apellidos = Usuario.Apellidos;
                UsuarioActual.Edad = Usuario.Edad;
                UsuarioActual.ContraseñaWeb = Usuario.ContraseñaWeb;

                await contexto.SaveChangesAsync();
            }
        }
        public async Task Delete(Guid id)
        {
            var UsuarioActual = contexto.Usuarios.Find(id);

            if (UsuarioActual != null)
            {
                contexto.Remove(UsuarioActual);
                await contexto.SaveChangesAsync();
            }
        }
    }
}