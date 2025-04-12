using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Validators
{
    public class WordValidator : IWordValidator
    {
        public void ThrowIfEnglishNameIsNull(string name)
        {
            if (name == null)
            {
                throw new BadRequestException("Angielska nazwa słowa jest wymagana!");
            }
        }

        public void ThrowIfPolishNameIsNull(string name)
        {
            if (name == null)
            {
                throw new BadRequestException("Polska nazwa słowa jest wymagana!");
            }
        }

        public void ThrowIfWordIsNull(Word? word)
        {
            if (word == null)
            {
                throw new NotFoundException("Nie znaleziono słowa o takim numerze Id!");
            }
        }
    }
}
