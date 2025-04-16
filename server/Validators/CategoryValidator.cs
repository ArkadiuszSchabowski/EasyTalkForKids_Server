using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Validators
{
    public class CategoryValidator : ICategoryValidator
    {
        public void ThrowIfPolishNameIsNullOrEmpty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BadRequestException("Polska nazwa kategorii jest wymagana!");
            }
        }

        public void ThrowIfEnglishNameIsNullOrEmpty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BadRequestException("Angielska nazwa kategorii jest wymagana!");
            }
        }
        public void ThrowIfPolishNameExists(Category? category)
        {
            if (category != null)
            {
                throw new ConflictException("Polska nazwa kategorii istnieje już w bazie danych!");
            }
        }

        public void ThrowIfEnglishNameExists(Category? category)
        {
            if (category != null)
            {
                throw new ConflictException("Angielska nazwa kategorii istnieje już w bazie danych!");
            }
        }
        public void ThrowIfCategoryIsNull(Category? category)
        {
            if (category == null)
            {
                throw new NotFoundException("Nie znaleziono kategorii o takim numerze Id!");
            }
        }
    }
}
