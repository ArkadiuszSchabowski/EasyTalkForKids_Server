namespace EasyTalkForKids_Server.Interfaces
{
    public interface IService<T> where T : class
    {
        void Add(T item);
        List<T> Get();
        T Get(int id);
        void Remove(int id);
    }
}
