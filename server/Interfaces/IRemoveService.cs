namespace EasyTalkForKids.Interfaces
{
    public interface IRemoveService<T> where T : class
    {
        void Remove(int id);
    }
}