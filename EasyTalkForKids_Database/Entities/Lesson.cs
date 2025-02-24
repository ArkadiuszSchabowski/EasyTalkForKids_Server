namespace EasyTalkForKids_Database.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public List<Word> Words { get; set; } = [];
    }
}