namespace EasyTalkForKids.Models
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<GetLessonDto> Lessons { get; set; } = new List<GetLessonDto>();
    }
}
