namespace EasyTalkForKids.Interfaces
{
    public interface INameRepository<T> where T : class
    {
        T? GetByPolishName(string name);
        T? GetByEnglishName(string name);
    }
}
