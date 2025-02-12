using EasyTalkForKids_Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyTalkForKids_Database
{
    public class MyDbContext : DbContext
    {
        public DbSet<Word> Words { get; set; }
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }
    }
}
