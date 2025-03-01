namespace EasyTalkForKids.Models
{
    public class AddCategoryDto
    {
        public string Name { get; set; } = string.Empty;
        public List<AddLessonDto> Lessons { get; set; } = new List<AddLessonDto>();
    }
}
