namespace EasyTalkForKids.Interfaces
{
    public interface ICategoryValidator
    {
        void ThrowIfPolishNameExists(string name);
        void ThrowIfEnglishNameExists(string name);
    }
}
