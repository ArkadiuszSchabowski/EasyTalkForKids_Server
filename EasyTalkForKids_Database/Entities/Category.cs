namespace EasyTalkForKids_Database.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string PolishName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
