using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Models
{
    public class CategoryDto
    {
        public int? Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
