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
            return _context.User.Include(u => u.Friends).ThenInclude(f => f.UserFriend).FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User.ToList();
        }

        public void Add(User model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(User model)
        {
            throw new NotImplementedException();
        }
    }
}
