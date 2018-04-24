using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR.DAL2.Interfaces
{
   public interface IRepository<T> : IDisposable  where T : class
    {
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        T Get(Int64 id);
        void Create(T item);
        void Update(T item);

        void Delete(Int64 id);
    }
}
