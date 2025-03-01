using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Models
{
    public class AddWordDto
    {
        public int LessonNumber { get; set; }
        public int LandNumber { get; set; }
        public string PolishName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int LessonId { get; set; }
    }
}
