using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Interfaces
{
    public interface IWordValidator
    {
        public void ThrowIfWordIsNull(Word? word);
    }
}
