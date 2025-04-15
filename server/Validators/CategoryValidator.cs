using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Validators
{
    public class CategoryValidator : ICategoryValidator
    {
        private readonly IRepositoryCategory _repositoryCategory;

        public CategoryValidator(IRepositoryCategory repositoryCategory)
        {
            _repositoryCategory = repositoryCategory;
        }
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
        public void ThrowIfPolishNameExists(string name)
        {
            var category = _repositoryCategory.GetByPolishName(name);

            if (category != null)
            {
                throw new ConflictException("Polska nazwa kategorii istnieje już w bazie danych!");
            }
        }

        public void ThrowIfEnglishNameExists(string name)
        {
            var category = _repositoryCategory.GetByEnglishName(name);

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
