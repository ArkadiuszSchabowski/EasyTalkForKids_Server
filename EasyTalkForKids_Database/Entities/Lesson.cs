namespace EasyTalkForKids_Database.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public Topic? Topic { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<Word> Words { get; set; } = new List<Word>();
    }
}
