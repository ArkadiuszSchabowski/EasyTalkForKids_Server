namespace EasyTalkForKids_Server.Interfaces
{
    public interface IService<T> where T : class
    {
        void Add(T dto);
        List<T> Get();
        List<T> Get(int id);
    }
}
