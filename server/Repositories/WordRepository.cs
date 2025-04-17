using EasyTalkForKids.Interfaces;
using EasyTalkForKids_Database;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Repositories
{
    public class WordRepository : IRepository<Word>, INameRepository<Word>
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
            return _context.Words.SingleOrDefault(w => w.Id == id);
        }

        public Word? GetByEnglishName(string name)
        {
            return _context.Words.SingleOrDefault(w => w.EnglishName == name);
        }

        public Word? GetByPolishName(string name)
        {
            return _context.Words.SingleOrDefault(w => w.PolishName == name);
        }

        public void Remove(Word item)
        {
            _context.Words.Remove(item);
            _context.SaveChanges();
        }
    }
}