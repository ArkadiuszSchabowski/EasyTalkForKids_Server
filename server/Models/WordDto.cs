namespace EasyTalkForKids.Models
{
    public class WordDto
    {
        public int? Id { get; set; }
        public int LessonNumber { get; set; }
        public int LandNumber { get; set; }
        public string PolishName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}
