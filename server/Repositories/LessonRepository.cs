using EasyTalkForKids.Interfaces;
using EasyTalkForKids_Database;
using EasyTalkForKids_Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyTalkForKids.Repositories
{
    public class LessonRepository : IRepository<Lesson>, INameRepository<Lesson>
    {
        private readonly MyDbContext _context;

        public LessonRepository(MyDbContext context)
        {
            _context = context;
        }
        public void Add(Lesson item)
        {
            _context.Lessons.Add(item);
            _context.SaveChanges();
        }
        public List<Lesson> Get()
        {
            return _context.Lessons.Include(l => l.Words).ToList();
        }

        public Lesson? Get(int id)
        {
            return _context.Lessons.Include(l => l.Words).SingleOrDefault(l => l.Id == id);
        }

        public Lesson? GetByEnglishName(string name)
        {
            return _context.Lessons.Include(l => l.Words).SingleOrDefault(l => l.EnglishName == name);
        }

        public Lesson? GetByPolishName(string name)
        {
            return _context.Lessons.Include(l => l.Words).SingleOrDefault(l => l.PolishName == name);
        }

        public void Remove(Lesson item)
        {
            _context.Lessons.Remove(item);
            _context.SaveChanges();
        }
    }
}
