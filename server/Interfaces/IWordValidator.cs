using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Interfaces
{
    public interface IWordValidator
    {
        public void ThrowIfEnglishNameIsNull(string name);
        public void ThrowIfPolishNameIsNull(string name);
        public void ThrowIfWordIsNull(Word? word);
    }
}
