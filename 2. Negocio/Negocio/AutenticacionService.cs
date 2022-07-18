using Autenticacion;
using Contexto;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class AutenticacionService : IAutenticacionService
    {
        BancoContexto contexto;
        public AutenticacionService(BancoContexto contexto)
        {
            this.contexto = contexto;
        }

        public AuthEntity? validateAuth(string usuario, string pass)
        {
            if (usuario == null) return null;
            if (pass == null) return null;

            var autenticacion = contexto.Auths.Where(
                a => a.Usuario.Equals(usuario)).Where(
                b => b.Password.Equals(pass)).FirstOrDefault();

            if (autenticacion == null) return null;

            return autenticacion;
        }
    }
}
