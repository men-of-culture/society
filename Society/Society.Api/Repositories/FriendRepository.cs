using Microsoft.EntityFrameworkCore;
using Society.Api.Models;

namespace Society.Api.Repositories
{
    public class FriendRepository : IRepository<Friend>
    {
        private readonly DatabaseContext _context;

        public FriendRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Friend GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Friend> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Add(Friend model)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Update(Friend model)
        {
            throw new NotImplementedException();
        }
    }
}
