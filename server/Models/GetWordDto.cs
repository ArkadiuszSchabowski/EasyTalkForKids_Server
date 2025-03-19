namespace EasyTalkForKids.Models
{
    public class GetWordDto
    {
        public int Id { get; set; }
        public string PolishName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int LessonId { get; set; }
    }
}
