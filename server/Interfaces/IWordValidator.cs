using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Interfaces
{
    public interface IWordValidator
    {
        public void ThrowIfPolishNameIsNullOrEmpty(string name);
        public void ThrowIfEnglishNameIsNullOrEmpty(string name);
        public void ThrowIfWordIsNull(Word? word);
        void ThrowIfPolishNameExists(Word? word);
        void ThrowIfEnglishNameExists(Word? word);
    }
}
