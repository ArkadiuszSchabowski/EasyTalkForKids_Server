using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Models
{
    public class AddTopicDto
    {
        public string PolishName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
    }
}
