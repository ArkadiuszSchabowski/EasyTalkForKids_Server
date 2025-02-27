using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Models
{
    public class LessonDto
    {
        public int? Id { get; set; }
        public int TopicId { get; set; }
        public int CategoryId { get; set; }
        public List<Word> Words { get; set; } = new List<Word>();
    }
}
