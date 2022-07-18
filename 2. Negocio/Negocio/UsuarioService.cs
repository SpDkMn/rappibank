using BancoEntity;
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
        public IEnumerable<UsuarioEntity> Get()
        {
            return contexto.Usuarios;
        }
        public async Task Save(UsuarioBE Usuario)
        {
            UsuarioEntity NuevoUsuario = new UsuarioEntity();
            NuevoUsuario.UsuarioId = new Guid();
            NuevoUsuario.Nombres = Usuario.Nombres;
            NuevoUsuario.Apellidos = Usuario.Apellidos;
            NuevoUsuario.Edad = Usuario.Edad;
            NuevoUsuario.ContraseñaWeb = Usuario.ContraseñaWeb;

            contexto.Add(NuevoUsuario);
            await contexto.SaveChangesAsync();
        }
        public UsuarioEntity? GetUsuario(Guid id)
        {
            var UsuarioActual = contexto.Usuarios.Include(p => p.Cuentas).Where(p => p.UsuarioId == id).FirstOrDefault();  //.Find(id);
            return UsuarioActual;
        }
        public async Task Update(Guid id, UsuarioBE Usuario)
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