using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Validators
{
    public class LessonValidator : ILessonValidator
    {
        public void ThrowIfPolishNameIsNullOrEmpty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BadRequestException("Polska nazwa lekcji jest wymagana!");
            }
        }

        public void ThrowIfEnglishNameIsNullOrEmpty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BadRequestException("Angielska nazwa lekcji jest wymagana!");
            }
        }
        public void ThrowIfPolishNameExists(Lesson? lesson)
        {
            if (lesson != null)
            {
                throw new ConflictException("Polska nazwa lekcji istnieje już w bazie danych!");
            }
        }

        public void ThrowIfEnglishNameExists(Lesson? lesson)
        {
            if (lesson != null)
            {
                throw new ConflictException("Angielska nazwa lekcji istnieje już w bazie danych!");
            }
        }
        public void ThrowIfLessonIsNull(Lesson? lesson)
        {
            if (lesson == null)
            {
                throw new NotFoundException("Nie znaleziono lekcji o takim numerze Id!");
            }
        }
    }
}
