namespace EasyTalkForKids.Models
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string PolishName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public List<GetLessonDto> Lessons { get; set; } = new List<GetLessonDto>();
    }
}
