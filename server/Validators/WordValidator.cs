using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Validators
{
    public class WordValidator : IWordValidator
    {
        public void ThrowIfPolishNameIsNullOrEmpty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BadRequestException("Polska nazwa słowa jest wymagana!");
            }
        }
        public void ThrowIfEnglishNameIsNullOrEmpty(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new BadRequestException("Angielska nazwa słowa jest wymagana!");
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
