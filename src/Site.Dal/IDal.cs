using System.Collections.Generic;
namespace Site.Dal
{
    public interface IDal<T>: System.IDisposable
    {
        T Insert(T value);
        bool Edit(T value);
        bool Delete(T value);
        bool Delete(object id);
        T Find(object id);
        IEnumerable<T> List();
    }
}
