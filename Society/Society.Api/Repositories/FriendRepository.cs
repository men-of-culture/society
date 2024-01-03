using Microsoft.EntityFrameworkCore;
using Society.Shared.Models;
using System.Data.Common;

namespace Society.Api.Repositories
{
    public class FriendRepository
    {
        private readonly DatabaseContext _context;

        public FriendRepository(DatabaseContext databaseContext)
        {
            _context = databaseContext;
        }

        public IEnumerable<Friend> GetAllById(Guid id)
        {
            return _context.Friend.Include(x => x.UserFriend).Where(x => x.UserId == id);
        }

        public void AddFriend(User user, User friendUser)
        {
            var Friend = new Friend
            {
                UserId = user.Id,
                User = user,
                FriendId = friendUser.Id,
                UserFriend = friendUser
            };
            _context.Friend.Add(Friend);
            _context.SaveChanges();
        }

        public void DeleteFriend(User user, User friendUser)
        {
            var Friend = new Friend
            {
                UserId = user.Id,
                User = user,
                FriendId = friendUser.Id,
                UserFriend = friendUser
            };
            _context.Friend.Remove(Friend);
            _context.SaveChanges();
        }
    }
}
