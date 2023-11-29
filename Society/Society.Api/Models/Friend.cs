namespace Society.Api.Models
{
    public class Friend
    {
        public Guid UserId { get; set; }
        public User User { get; set; } = new();
        public Guid FriendId { get; set; }
        public User UserFriend { get; set; } = new();


        public string FriendName { get; set; } = string.Empty;
        public byte[]? FriendImage { get; set; }
    }
}
