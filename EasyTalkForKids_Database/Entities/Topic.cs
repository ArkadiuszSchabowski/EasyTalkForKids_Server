﻿namespace EasyTalkForKids_Database.Entities
{
    public class Topic
    {
        public int Id { get; set; }
        public string PolishName { get; set; } = string.Empty;
        public string EnglishName { get; set; } = string.Empty;
        public Lesson? Lesson { get; set; }
    }
}
