using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interfaces.IGenericas
{
    public interface IGenerica<T> where T : class
    {
        Task Add(T objeto);
        Task Update(T objeto);
        Task Delete(T objecto);
        Task<T> GetByID(int id);
        Task<List<T>> List();
    }
}
