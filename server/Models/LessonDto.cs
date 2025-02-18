namespace EasyTalkForKids.Models
{
    public class LessonDto
    {
        public int? Id { get; set; }
        public List<WordDto> WordsDto { get; set; } = new List<WordDto>();
    }
}
