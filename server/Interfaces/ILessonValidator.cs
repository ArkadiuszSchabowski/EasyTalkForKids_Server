using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Interfaces
{
    public interface ILessonValidator
    {
       public void ThrowIfPolishNameIsNull(string name);
       public void ThrowIfEnglishNameIsNull(string name);
       public void ThrowIfLessonIsNull(Lesson? lesson);
    }
}
