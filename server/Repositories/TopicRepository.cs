using EasyTalkForKids.Interfaces;
using EasyTalkForKids_Database;
using EasyTalkForKids_Database.Entities;

namespace EasyTalkForKids.Repositories
{
    public class TopicRepository : IRepository<Topic>
    {
        private readonly MyDbContext _context;

        public TopicRepository(MyDbContext context)
        {
            _context = context;
        }
        public void Add(Topic item)
        {
            _context.Topics.Add(item);
            _context.SaveChanges();
        }
        public List<Topic> Get()
        {
            return _context.Topics.ToList();
        }

        public Topic? Get(int id)
        {
            return _context.Topics.SingleOrDefault(t => t.Id == id);
        }
        public void Remove(Topic item)
        {
            _context.Topics.Remove(item);
            _context.SaveChanges();
        }
    }
}
