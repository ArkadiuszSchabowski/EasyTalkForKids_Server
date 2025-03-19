namespace EasyTalkForKids.Models
{
    public class GetLessonDto
    {
        public int Id { get; set; }
        public string PolishName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public List<GetWordDto> WordsDto { get; set; } = new List<GetWordDto>();
    }
}
