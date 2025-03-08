using EasyTalkForKids_Database.Entities;
using EasyTalkForKids_Database;
using EasyTalkForKids.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyTalkForKids.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }
        public void Add(Category item)
        {
            _context.Categories.Add(item);
            _context.SaveChanges();
        }
        public List<Category> Get()
        {
            return _context.Categories.Include(c => c.Lessons).ToList();
        }

        public Category? Get(int id)
        {
            return _context.Categories.Include(c => c.Lessons).SingleOrDefault(c => c.Id == id);
        }
        public void Remove(Category item)
        {
            _context.Categories.Remove(item);
            _context.SaveChanges();
        }
    }
}
