using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Society.Shared.Models;

namespace Society.Api.Repositories
{
    public class FriendRepository
    {
        private readonly DatabaseContext _context;

        public FriendRepository(DatabaseContext context)
        {
            _context = context;
        }

        public Friend GetById(Guid userId, Guid friendId)
        {
            return _context.Friend.FirstOrDefault(x => x.UserId == userId && x.FriendId == friendId) ?? new Friend();
        }

        public IEnumerable<Friend> GetAll(Guid userId)
        {
            return _context.Friend.ToList().FindAll(x => x.UserId == userId);
        }

        public void Add(Friend friend)
        {
            _context.Friend.Add(friend);
            _context.SaveChanges();
        }

        public void Delete(Guid userId, Guid friendId)
        {
            var friend = _context.Friend.FirstOrDefault(x => x.UserId == userId && x.FriendId == friendId);
            if (friend is not null)
            {
                _context.Friend.Remove(friend);
                _context.SaveChanges();
            }
        }

        public void Update(Friend friend)
        {
            _context.Friend.Update(friend);
            _context.SaveChanges();
        }
    }
}
