using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Interfaces
{
    public interface ICategoryValidator
    {
        void ThrowIfPolishNameIsNullOrEmpty(string name);
        void ThrowIfEnglishNameIsNullOrEmpty(string name);
        void ThrowIfPolishNameExists(string name);
        void ThrowIfEnglishNameExists(string name);
        void ThrowIfCategoryIsNull(Category? category);
    }
}