using EasyTalkForKids.Exceptions;
using EasyTalkForKids.Interfaces;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Validators
{
    public class WordValidator : IWordValidator
    {
        public void ThrowIfWordIsNull(Word? word)
        {
            if (word == null)
            {
                throw new NotFoundException("Nie znaleziono słowa o takim numerze Id!");
            }
        }
    }
}
