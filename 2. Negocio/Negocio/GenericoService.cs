using Contexto;
using IntefacesNegocios;
using Microsoft.EntityFrameworkCore;

namespace Negocio
{
    public class GenericoService<T> : IGenericoService<T> where T : class
    {
        BancoContexto contexto;
        public GenericoService(BancoContexto contexto)
        {
            this.contexto = contexto;
        }
        public async Task<List<T>> Get()
        {
            return await contexto.Set<T>().ToListAsync();
        }
        public async Task<T> GetObj(Guid id)
        {
            return await contexto.Set<T>().FindAsync(id);
        }

        public async Task Save(T obj)
        {
            contexto.Set<T>().Add(obj);
            await contexto.SaveChangesAsync();
        }

        public async Task Update(Guid id, T obj)
        {
            contexto.Entry(obj).State = EntityState.Modified;
            await contexto.SaveChangesAsync();
        }
        public async Task Delete(Guid id)
        {
            var obj = contexto.Set<T>().Find(id);
            if (obj != null)
            {
                contexto.Remove(obj);
                await contexto.SaveChangesAsync();
            } 
        }
    }
}
