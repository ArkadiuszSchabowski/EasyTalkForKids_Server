namespace EasyTalkForKids.Models
{
    public class GetCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<AddLessonDto> Lessons { get; set; } = new List<AddLessonDto>();
    }
}
