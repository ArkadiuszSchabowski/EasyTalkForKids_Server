﻿namespace EasyTalkForKids_Database.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
