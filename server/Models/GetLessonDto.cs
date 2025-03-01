namespace EasyTalkForKids.Models
{
    public class GetLessonDto
    {
        public int Id { get; set; }
        public int TopicId { get; set; }
        public int CategoryId { get; set; }
        public List<AddWordDto> WordsDto { get; set; } = new List<AddWordDto>();
    }
}
