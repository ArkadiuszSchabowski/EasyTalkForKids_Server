namespace EasyTalkForKids.Models
{
    public class AddLessonDto
    {
        public string PolishName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
    }
}