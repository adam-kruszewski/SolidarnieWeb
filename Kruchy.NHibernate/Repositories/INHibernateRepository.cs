using System.Collections.Generic;

namespace Kruchy.NHibernate.Repositories
{
    public interface INHibernateRepository<T>
       where T : class
    {
        T Load(object id);

        T Get(object id);

        T Save(T o);

        void Update(T o);

        void Delete(T o);

        IList<T> GetAll();

        void Flush();
    }
}