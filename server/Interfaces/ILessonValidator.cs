using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Interfaces
{
    public interface ILessonValidator
    {
       public void ThrowIfPolishNameIsNullOrEmpty(string name);
       public void ThrowIfEnglishNameIsNullOrEmpty(string name);
       public void ThrowIfLessonIsNull(Lesson? lesson);
        void ThrowIfPolishNameExists(Lesson? lesson);
        void ThrowIfEnglishNameExists(Lesson? lesson);
    }
}
