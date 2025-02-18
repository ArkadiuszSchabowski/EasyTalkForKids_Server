using EasyTalkForKids.Interfaces;
using EasyTalkForKids_Database;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Repositories
{
    public class WordRepository : IRepository<Word>
    {
        private readonly MyDbContext _context;

        public WordRepository(MyDbContext context)
        {
            _context = context;
        }
        public void Add(Word item)
        {
            _context.Words.Add(item);
            _context.SaveChanges();
        }
        public List<Word> Get()
        {
            return _context.Words.ToList();
        }

        public Word? Get(int id)
        {
            return _context.Words.SingleOrDefault(x => x.Id == id);
        }
        public void Remove(Word item)
        {
            _context.Words.Remove(item);
            _context.SaveChanges();
        }
    }
}