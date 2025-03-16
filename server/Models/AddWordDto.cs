namespace EasyTalkForKids.Models
{
    public class AddWordDto
    {
        public int LessonId { get; set; }
        public string PolishName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
