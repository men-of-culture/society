using System.Text.Json.Serialization;

namespace Society.Api.Models
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public byte[]? Image { get; set; }
        public ICollection<Friend>? Friends { get; set; }
    }

    public class FriendDto
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = new();
        public Guid FriendId { get; set; }
        public User UserFriend { get; set; } = new();


        public string FriendName { get; set; } = string.Empty;
        public byte[]? FriendImage { get; set; }
    }
}
