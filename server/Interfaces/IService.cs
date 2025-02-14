using EasyTalkForKids.Models;

namespace EasyTalkForKids_Server.Interfaces
{
    public interface IService<T> where T : class
    {
        void Add(T dto);
        List<T> Get();
    }
}
