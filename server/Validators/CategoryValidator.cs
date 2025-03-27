using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;

namespace EasyTalkForKids.Validators
{
    public class CategoryValidator : ICategoryValidator
    {
        private readonly IRepositoryCategory _repositoryCategory;

        public CategoryValidator(IRepositoryCategory repositoryCategory)
        {
            _repositoryCategory = repositoryCategory;
        }
        public void ThrowIfPolishNameIsNull(string name)
        {
            if (name == null)
            {
                throw new BadRequestException("Polska nazwa kategorii jest wymagana!");
            }
        }

        public void ThrowIfEnglishNameIsNull(string name)
        {
            if (name == null)
            {
                throw new BadRequestException("Angielska nazwa kategorii jest wymagana!");
            }
        }
        public void ThrowIfPolishNameExists(string name)
        {
            var category = _repositoryCategory.GetByPolishName(name);

            if (category != null)
            {
                throw new ConflictException("Polska nazwa kategorii isnieje już w bazie danych!");
            }
        }

        public void ThrowIfEnglishNameExists(string name)
        {
            var category = _repositoryCategory.GetByEnglishName(name);

            if (category != null)
            {
                throw new ConflictException("Angielska nazwa kategorii isnieje już w bazie danych!");
            }
        }
    }
}
