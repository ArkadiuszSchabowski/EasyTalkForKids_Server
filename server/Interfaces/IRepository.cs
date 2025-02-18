namespace EasyTalkForKids.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);
        List<T> Get();
        T? Get(int id);
        void Remove(T item);
    }
}