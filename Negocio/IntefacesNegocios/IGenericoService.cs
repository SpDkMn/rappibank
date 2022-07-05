using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntefacesNegocios
{
    public interface IGenericoService<T> where T : class
    {
        public Task<List<T>> Get();
        public Task Save(T obj);
        public Task<T> GetObj(Guid id);
        public Task Update(Guid id, T obj);
        public Task Delete(Guid id);

    }
}
