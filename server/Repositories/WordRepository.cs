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
    }
}
