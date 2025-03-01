namespace EasyTalkForKids.Models
{
    public class AddLessonDto
    {
        public int TopicId { get; set; }
        public int CategoryId { get; set; }
        public List<AddWordDto> WordsDto { get; set; } = new List<AddWordDto>();
    }
}
