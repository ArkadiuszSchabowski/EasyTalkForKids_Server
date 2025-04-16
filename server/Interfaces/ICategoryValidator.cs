using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Interfaces
{
    public interface ICategoryValidator
    {
        void ThrowIfPolishNameIsNullOrEmpty(string name);
        void ThrowIfEnglishNameIsNullOrEmpty(string name);
        void ThrowIfPolishNameExists(Category? category);
        void ThrowIfEnglishNameExists(Category? category);
        void ThrowIfCategoryIsNull(Category? category);
    }
}