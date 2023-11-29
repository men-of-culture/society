using Microsoft.EntityFrameworkCore;
using Society.Api.Models;

namespace Society.Api.Repositories
{
    public class UserRepository : IRepository<User>
    {
        private readonly DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public User GetById(Guid id)
        {
            return _context.User.Find(id)!;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

        public void Add(User model)
        {
            _context.User.Add(model);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = _context.User.Find(id);
            _context.User.Remove(user!);
            _context.SaveChanges();
        }

        public void Update(User model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
    }
}
