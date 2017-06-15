using System.Collections.Generic;

namespace Kruchy.NHibernate.Repositories
{
    public interface INHibernateRepository<T>
       where T : class
    {
        T Get(object id);

        T Save(T o);

        void Update(T o);

        IList<T> GetAll();

        void Flush();
    }
}