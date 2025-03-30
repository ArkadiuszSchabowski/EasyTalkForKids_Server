using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Interfaces
{
    public interface ICategoryValidator
    {
        void ThrowIfPolishNameIsNull(string name);
        void ThrowIfEnglishNameIsNull(string name);
        void ThrowIfPolishNameExists(string name);
        void ThrowIfEnglishNameExists(string name);
        void ThrowIfCategoryIsNull(Category? category);
    }
}