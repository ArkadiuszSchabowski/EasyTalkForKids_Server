namespace EasyTalkForKids.Interfaces
{
    public interface IGetService<T> where T : class
    {
        List<T> Get();
        T Get(int id);
    }
}
