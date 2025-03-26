using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Interfaces
{
    public interface IRepositoryCategory
    {
        Category? GetByPolishName(string name);
        Category? GetByEnglishName(string name);
    }
}
