﻿using EasyTalkForKids_Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyTalkForKids_Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<Word> Words { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>()
                .HasMany(l => l.Words)
                .WithOne(w => w.Lesson)
                .HasForeignKey(w => w.LessonId);
        }
    }
}
